using BookManagementApi.Models;

namespace BookManagementApi.Data
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<Book> GetBookByIdAsync(int id);
        Task AddBookAsync(Book book);
        Task AddBooksAsync(IEnumerable<Book> books);
        Task UpdateBookAsync(Book book);
        Task SoftDeleteBookAsync(int id);
        Task SoftDeleteBooksAsync(IEnumerable<int> ids);
        Task<bool> BookExistsAsync(string title);
    }
}
