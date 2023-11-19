using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SupermarkerWEB.Data;
using SupermarkerWEB.Models;

namespace SupermarkerWEB.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly SupermarketContext _context;
        public CreateModel(SupermarketContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {   
            return Page();
        }

        [BindProperty]
        public Category Category { get; set; } = default!;

        public async Task<ActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Categories == null || Category == null)
            {
                return Page();
            }
            _context.Categories.Add(Category);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
