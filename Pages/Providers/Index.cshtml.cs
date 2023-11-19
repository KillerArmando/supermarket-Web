using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarkerWEB.Data;
using SupermarkerWEB.Models;

namespace SupermarkerWEB.Pages.Providers
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly SupermarketContext _context;

        public IndexModel(SupermarketContext context)
        {
            _context = context;
        }
        public IList<Provider> Providers { get; set; } = default!;
        public async Task OnGetAsync()
        {
            if (_context.Provider != null)
            {
                Providers = await _context.Provider.ToListAsync();
            }
        }

    }
}
