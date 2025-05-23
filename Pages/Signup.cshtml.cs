using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyInventoryApp.Models;   // Your User model namespace
using System.Threading.Tasks;

public class SignupModel : PageModel
{
    private readonly AppDbContext _context;

    public SignupModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public SignupInputModel Input { get; set; } = new SignupInputModel();

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        if (Input.Password != Input.ConfirmPassword)
        {
            ModelState.AddModelError(string.Empty, "Passwords do not match.");
            return Page();
        }

        var hashed = BCrypt.Net.BCrypt.HashPassword(Input.Password);

        var user = new User
        {
            Username = Input.Username,
            PasswordHash = hashed,
            RoleId = 2 // Customer role id
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return RedirectToPage("/Login");
    }
}