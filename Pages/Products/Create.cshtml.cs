using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SupermarkerWEB.Data;
using SupermarkerWEB.Models;

namespace SupermarkerWEB.Pages.Products
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
            ListCategory();
            return Page();
        }

        

        [BindProperty]
        public Product product { get; set; } = default!;

        public SelectList Categories { get; set; }

        private void ListCategory()
        {
            var categories = _context.Categories.ToList();
            Categories = new SelectList(categories, "Id", "Name");
        }

        public async Task<ActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Products == null || product == null)
            { 
            ListCategory();
            return Page(); 
            }
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
