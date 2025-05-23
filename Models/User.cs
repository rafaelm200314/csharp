public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;

    // Foreign key for Role
    public int RoleId { get; set; }

    // Navigation property (optional)
    public Role? Role { get; set; }
}