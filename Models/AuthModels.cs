using System.ComponentModel.DataAnnotations;

namespace BookManagementApi.Models
{
    public class AuthRequest
    {
        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Password { get; set; }
    }

    public class AuthResponse
    {
        public string? Username { get; set; }
        public string? Token { get; set; }
        public int ExpiresIn { get; set; }
    }
}
