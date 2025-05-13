using System.ComponentModel.DataAnnotations;

namespace Registry.Data.Models;

public class User
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Username { get; set; }

    [Required]
    public string PasswordHash { get; set; }

    [Required]
    public string Role { get; set; } // "admin" or "registry"
}
