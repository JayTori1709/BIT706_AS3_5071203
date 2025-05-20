using System;
using System.Collections.Generic;
using System.Linq;
using Registry.Data.Models;

namespace Registry.Data.Services
{
    public class MicrochipService
    {
        private readonly RegistryDbContext _context;

        public MicrochipService(RegistryDbContext context)
        {
            _context = context;
        }

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

        public void AssignMicrochipToAnimal(int microchipId, int animalId)
        {
            var chip = _context.Microchips.Find(microchipId);
            if (chip != null)
            {
                chip.AnimalId = animalId;
                _context.SaveChanges();
            }
        }

        public void DeleteUnusedChips()
        {
            var unused = _context.Microchips.Where(c => c.AnimalId == null);
            _context.Microchips.RemoveRange(unused);
            _context.SaveChanges();
        }

        public List<Microchip> GetUnassignedChips()
        {
            return _context.Microchips
                .Where(m => m.AnimalId == null)
                .ToList();
        }
    }
}