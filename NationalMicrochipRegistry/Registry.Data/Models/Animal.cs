using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // Add this

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

    // Foreign Key for Microchip
    public int? MicrochipId { get; set; }  // Make it nullable
    [ForeignKey("MicrochipId")]
    public Microchip AssignedMicrochip { get; set; } // Navigation property
    public int ClinicId { get; set; }
}