using System.Security.Cryptography;
using System.Text;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Services
{
    public class AuthService
    {
        private readonly SupermarketContext _context;

        public AuthService(SupermarketContext context)
        {
            _context = context;
        }

        public User? Login(string username, string password)
        {
            var passwordHash = HashPassword(password);
            return _context.Users.FirstOrDefault(u =>
                u.Username == username && u.PasswordHash == passwordHash);
        }

        public static string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}

