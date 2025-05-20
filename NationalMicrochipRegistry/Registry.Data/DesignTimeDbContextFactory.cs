using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Registry.Data;

namespace Registry.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<RegistryDbContext>
    {
        public RegistryDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RegistryDbContext>();

            // Replace with your actual connection string
            var connectionString = "server=localhost;database=RegistryDB;user=root;password=l3nardw12";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            return new RegistryDbContext(optionsBuilder.Options);
        }
    }
}
