using Microsoft.EntityFrameworkCore;
using Registry.Data;
using Registry.Data.Models;
using Registry.Data.Services;
using Xunit;

namespace Registry.Tests
{
    public class ClinicServiceTests
    {
        [Fact]
        public void AddClinic_ShouldAddClinic()
        {
            var options = new DbContextOptionsBuilder<RegistryDbContext>()
                .UseInMemoryDatabase("AddClinicTest")
                .Options;

            using var context = new RegistryDbContext(options);
            var service = new ClinicService(context);

            var clinic = new Clinic { Name = "PetCare Clinic", Address = "123 Street" };
            service.AddClinic(clinic);

            Assert.Single(context.Clinics);
        }

        [Fact]
        public void DeleteClinic_ShouldRemoveClinic()
        {
            var options = new DbContextOptionsBuilder<RegistryDbContext>()
                .UseInMemoryDatabase("DeleteClinicTest")
                .Options;

            using var context = new RegistryDbContext(options);
            var clinic = new Clinic { Name = "Test Clinic", Address = "Nowhere" };
            context.Clinics.Add(clinic);
            context.SaveChanges();

            var service = new ClinicService(context);
            service.DeleteClinic(clinic.Id);

            Assert.Empty(context.Clinics);
        }
    }
}
