using System.Linq;
using Registry.Data.Models;

namespace Registry.Data.Services
{
    public class AnimalService
    {
        private readonly RegistryDbContext _context;

        public AnimalService(RegistryDbContext context)
        {
            _context = context;
        }

        public void AddAnimal(Animal animal)
        {
            _context.Animals.Add(animal);
            _context.SaveChanges();
        }

        public Animal FindByChip(int microchipId)
        {
            return _context.Microchips
                .Where(m => m.Id == microchipId && m.AnimalId != null)
                .Select(m => m.AssignedAnimal)
                .FirstOrDefault();
        }
    }
}
