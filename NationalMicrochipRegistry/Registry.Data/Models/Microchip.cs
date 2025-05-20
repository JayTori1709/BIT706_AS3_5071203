using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Registry.Data.Models;

public class Microchip
{
    public int Id { get; set; }

    [Required]
    [MaxLength(20)]
    public string SerialNumber { get; set; }

    public bool IsActive { get; set; } = true;

    public int? AnimalId { get; set; }

    [ForeignKey("AnimalId")]
    public Animal AssignedAnimal { get; set; }
    public int MicrochipId { get; internal set; }
}
