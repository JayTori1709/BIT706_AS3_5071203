using System.Linq;
using Registry.Data.Models;

namespace Registry.Data.Services
{
    /// <summary>
    /// Provides services related to animal management.
    /// </summary>
    public class AnimalService
    {
        private readonly RegistryDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="AnimalService"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public AnimalService(RegistryDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new animal to the database.
        /// </summary>
        /// <param name="animal">The animal to add.</param>
        public void AddAnimal(Animal animal)
        {
            _context.Animals.Add(animal);
            _context.SaveChanges();
        }

        /// <summary>
        /// Finds an animal assigned to a specific microchip.
        /// </summary>
        /// <param name="microchipId">The ID of the microchip.</param>
        /// <returns>The assigned animal, or null if none found.</returns>
        public Animal FindByChip(int microchipId)
        {
            return _context.Microchips
                .Where(m => m.Id == microchipId && m.AnimalId != null)
                .Select(m => m.AssignedAnimal)
                .FirstOrDefault();
        }
    }
}
