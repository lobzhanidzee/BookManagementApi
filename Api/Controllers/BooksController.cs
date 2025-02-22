using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BookManagementApi.Models;
using BookManagementApi.Data;

namespace BookManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var books = await _bookRepository.GetBooksAsync();
            var paginatedBooks = books.OrderByDescending(b => b.ViewsCount)
                                      .Skip((pageNumber - 1) * pageSize)
                                      .Take(pageSize)
                                      .Select(b => b.Title);
            return Ok(paginatedBooks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] Book book)
        {
            if (await _bookRepository.BookExistsAsync(book.Title))
            {
                return BadRequest("A book with the same title already exists.");
            }
            await _bookRepository.AddBookAsync(book);
            return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
        }

        [HttpPost("bulk")]
        public async Task<IActionResult> AddBooks([FromBody] IEnumerable<Book> books)
        {
            foreach (var book in books)
            {
                if (await _bookRepository.BookExistsAsync(book.Title))
                {
                    return BadRequest($"A book with the title '{book.Title}' already exists.");
                }
            }
            await _bookRepository.AddBooksAsync(books);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] Book book)
        {
            if (id != book.Id)
            {
                return BadRequest("Book ID mismatch.");
            }
            await _bookRepository.UpdateBookAsync(book);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteBook(int id)
        {
            await _bookRepository.SoftDeleteBookAsync(id);
            return NoContent();
        }

        [HttpDelete("bulk")]
        public async Task<IActionResult> SoftDeleteBooks([FromBody] IEnumerable<int> ids)
        {
            await _bookRepository.SoftDeleteBooksAsync(ids);
            return NoContent();
        }
    }
}
