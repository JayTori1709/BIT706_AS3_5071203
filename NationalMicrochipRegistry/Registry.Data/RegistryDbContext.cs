using Microsoft.EntityFrameworkCore;
using Registry.Data.Models;

namespace Registry.Data;

public class RegistryDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Clinic> Clinics { get; set; }
    public DbSet<Animal> Animals { get; set; }
    public DbSet<Microchip> Microchips { get; set; }

    public RegistryDbContext(DbContextOptions<RegistryDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Username)
            .IsUnique();

        modelBuilder.Entity<Microchip>()
            .HasIndex(m => m.SerialNumber)
            .IsUnique();
    }
}
