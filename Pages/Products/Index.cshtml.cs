using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyInventoryApp.Models;

namespace MyInventoryApp.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Product> Product { get; set; } = new(); // ✅ important

        public async Task OnGetAsync()
        {
            Product = await _context.Products.ToListAsync();
        }
    }
}