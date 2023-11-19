using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarkerWEB.Data;
using SupermarkerWEB.Models;

namespace SupermarkerWEB.Pages.Providers
{
    public class EditModel : PageModel
    {
        private readonly SupermarketContext _context;
        public EditModel(SupermarketContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Provider Provider { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Provider == null)
            {
                return NotFound();
            }
            var provider = await _context.Provider.FirstOrDefaultAsync(m => m.Id == id);
            if (provider == null)
            {
                return NotFound();
            }
            Provider = provider;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            _context.Attach(Provider).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(Provider.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }
            return RedirectToPage("./Index");
        }

        private bool CategoryExists(int id)
        {
            return (_context.Provider?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
