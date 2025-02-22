using System.ComponentModel.DataAnnotations;

namespace BookManagementApi.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string? Title { get; set; }

        [Required]
        [Range(0, 2025)]
        public int PublicationYear { get; set; }

        [Required]
        [StringLength(255)]
        public string? AuthorName { get; set; }

        public int ViewsCount { get; set; } = 0;
    }
}
