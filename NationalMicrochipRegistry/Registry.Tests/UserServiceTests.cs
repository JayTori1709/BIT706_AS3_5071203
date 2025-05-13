using Microsoft.EntityFrameworkCore;
using Registry.Data;
using Registry.Data.Models;
using Registry.Data.Services;
using Xunit;

namespace Registry.Tests
{
    public class UserServiceTests
    {
        [Fact]
        public void AddUser_ShouldAddUserToDatabase()
        {
            var options = new DbContextOptionsBuilder<RegistryDbContext>()
                .UseInMemoryDatabase("Test_AddUser")
                .Options;

            using var context = new RegistryDbContext(options);
            var service = new UserService(context);
            service.AddUser(new User { Username = "admin", PasswordHash = "1234", Role = "admin" });

            Assert.Single(context.Users);
        }

        [Fact]
        public void Authenticate_ShouldReturnCorrectUser()
        {
            var options = new DbContextOptionsBuilder<RegistryDbContext>()
                .UseInMemoryDatabase("Test_Authenticate")
                .Options;

            using var context = new RegistryDbContext(options);
            context.Users.Add(new User { Username = "admin", PasswordHash = "1234", Role = "admin" });
            context.SaveChanges();

            var service = new UserService(context);
            var result = service.Authenticate("admin", "1234");

            Assert.NotNull(result);
            Assert.Equal("admin", result.Username);
        }
    }
}
