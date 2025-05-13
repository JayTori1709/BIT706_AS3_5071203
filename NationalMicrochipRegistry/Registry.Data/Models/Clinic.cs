using System.ComponentModel.DataAnnotations;

namespace Registry.Data.Models;

public class Clinic
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [MaxLength(200)]
    public string Address { get; set; }
}
