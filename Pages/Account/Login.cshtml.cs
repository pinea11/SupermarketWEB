using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SupermarketWEB.Data;
using SupermarketWEB.Models;
using SupermarketWEB.Services;

namespace SupermarketWEB.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SupermarketContext _context;

        public LoginModel(SupermarketContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User User { get; set; }

        public string ErrorMessage { get; set; } = string.Empty;

        public IActionResult OnPost()
        {
            var passwordHash = AuthService.HashPassword(User.PasswordHash);

            var user = _context.Users.FirstOrDefault(u =>
                u.Username == User.Username && u.PasswordHash == passwordHash);

            if (user != null)
            {
                Session.CurrentUser = user;

                if (user.Role == "Administrador")
                    return RedirectToPage("/Index");

                if (user.Role =="Cliente")
                return RedirectToPage("/Cliente/Inicio");
            }

            ErrorMessage = "Credenciales incorrectas.";
            return Page();
        }
    }
}
