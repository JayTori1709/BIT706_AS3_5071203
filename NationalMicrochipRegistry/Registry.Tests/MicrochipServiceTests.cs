using Microsoft.EntityFrameworkCore;
using Registry.Data;
using Registry.Data.Models;
using Registry.Data.Services;
using Xunit;

namespace Registry.Tests
{
    public class MicrochipServiceTests
    {
        [Fact]
        public void GenerateMicrochips_ShouldAddSpecifiedCount()
        {
            var options = new DbContextOptionsBuilder<RegistryDbContext>()
                .UseInMemoryDatabase("GenerateChipsTest")
                .Options;

            using var context = new RegistryDbContext(options);
            var service = new MicrochipService(context);

            service.GenerateMicrochips(5);

            Assert.Equal(5, context.Microchips.Count());
        }

        [Fact]
        public void AssignMicrochipToAnimal_ShouldLinkAnimal()
        {
            var options = new DbContextOptionsBuilder<RegistryDbContext>()
                .UseInMemoryDatabase("AssignChipTest")
                .Options;

            using var context = new RegistryDbContext(options);
            var animal = new Animal { Name = "Rex", Species = "Dog", OwnerName = "Tom" };
            var chip = new Microchip { SerialNumber = "ABC123", IsActive = true };

            context.Animals.Add(animal);
            context.Microchips.Add(chip);
            context.SaveChanges();

            var service = new MicrochipService(context);
            service.AssignMicrochipToAnimal(chip.Id, animal.Id);

            Assert.Equal(animal.Id, context.Microchips.First().AnimalId);
        }
    }
}
