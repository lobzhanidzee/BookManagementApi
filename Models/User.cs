using System.ComponentModel.DataAnnotations;

namespace BookManagementApi.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string? Username { get; set; }

        [Required]
        [StringLength(255)]
        public string? PasswordHash { get; set; }
    }
}
