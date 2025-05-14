using System;
using System.Linq;
using Registry.Data.Models;

namespace Registry.Data.Services
{
    /// <summary>
    /// Provides services related to microchip management.
    /// </summary>
    public class MicrochipService
    {
        private readonly RegistryDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="MicrochipService"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public MicrochipService(RegistryDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Generates and adds a specified number of microchips to the database.
        /// </summary>
        /// <param name="count">The number of microchips to generate.</param>
        public void GenerateMicrochips(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var chip = new Microchip
                {
                    SerialNumber = Guid.NewGuid().ToString().Substring(0, 20),
                    IsActive = true
                };
                _context.Microchips.Add(chip);
            }
            _context.SaveChanges();
        }

        /// <summary>
        /// Assigns a microchip to a specific animal.
        /// </summary>
        /// <param name="microchipId">The microchip ID.</param>
        /// <param name="animalId">The animal ID.</param>
        public void AssignMicrochipToAnimal(int microchipId, int animalId)
        {
            var chip = _context.Microchips.Find(microchipId);
            chip.AnimalId = animalId;
            _context.SaveChanges();
        }

        /// <summary>
        /// Deletes all microchips that are not assigned to any animals.
        /// </summary>
        public void DeleteUnusedChips()
        {
            var unused = _context.Microchips.Where(c => c.AnimalId == null);
            _context.Microchips.RemoveRange(unused);
            _context.SaveChanges();
        }
    }
}
