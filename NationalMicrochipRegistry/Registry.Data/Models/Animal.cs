using System.ComponentModel.DataAnnotations;

namespace Registry.Data.Models;

public class Animal
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Species { get; set; }

    public string Breed { get; set; }

    [Required]
    public string OwnerName { get; set; }
}
