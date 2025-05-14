using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;
using SupermarketWEB.Services;

namespace SupermarketWEB.Pages.Providers
{
    public class IndexModel : PageModel
    {
        private readonly SupermarketContext _context;

        public IndexModel(SupermarketContext context)
        {
            _context = context;
        }

        public IList<Provider> Providers { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            if (Session.CurrentUser == null || Session.CurrentUser.Role != "Administrador")
            {
                RedirectToPage("/Account/Login");
            }
            if (_context.Providers != null)
            {
                Providers = await _context.Providers.ToListAsync();
            }
            return Page();

        }
    }
}

