using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace BookManagementApi.Handlers;
public static class PasswordHashHandler
{
    public static string HashPassword(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }
    }

    public static bool VerifyPassword(string password, string hashedPassword)
    {
        using (var sha256 = SHA256.Create())
        {
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            var hashedPasswordToCompare = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            return hashedPasswordToCompare == hashedPassword;
        }
    }
}
