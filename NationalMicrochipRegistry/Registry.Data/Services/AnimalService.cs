using System.Collections.Generic;
using System.Linq;
using Registry.Data.Models;
using Microsoft.EntityFrameworkCore; // Needed for Include()

namespace Registry.Data.Services
{
    /// <summary>
    /// Provides services related to animal management.
    /// </summary>
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
            // Eagerly load the Animal and its Microchip in one query
            return _context.Microchips
                .Include(m => m.AssignedAnimal) // Include the Animal navigation property
                .FirstOrDefault(m => m.MicrochipId == microchipId)?.AssignedAnimal;
        }

        public List<Animal> GetAnimalsWithoutChip()
        {
            //  Use .Where(a => a.MicrochipId == null)
            return _context.Animals
                .Where(a => a.MicrochipId == null)
                .ToList();
        }
    }
}