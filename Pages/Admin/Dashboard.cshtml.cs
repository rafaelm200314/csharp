using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyInventoryApp.Models; // if your models are here

namespace MyInventoryApp.Pages.Admin
{
    public class DashboardModel : PageModel
    {
        private readonly AppDbContext _context;

        public DashboardModel(AppDbContext context)
        {
            _context = context;
        }

        public int TotalUsers { get; set; }
        public int TotalOrders { get; set; }
        public int TotalProducts { get; set; }

        public async Task OnGetAsync()
        {
            TotalUsers = await _context.Users.CountAsync();
            TotalOrders = await _context.Orders.CountAsync();
            TotalProducts = await _context.Products.CountAsync();
        }
    }
}