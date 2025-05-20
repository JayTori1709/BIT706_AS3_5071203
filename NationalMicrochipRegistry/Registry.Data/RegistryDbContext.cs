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

        // Configure the relationship between Animal and Microchip
        modelBuilder.Entity<Animal>()
            .HasOne(a => a.AssignedMicrochip) // An Animal has one AssignedMicrochip
            .WithOne(m => m.AssignedAnimal) // A Microchip has one AssignedAnimal
            .HasForeignKey<Animal>(a => a.MicrochipId) // Foreign key is in Animal
            .IsRequired(false); // This is important: MicrochipId is nullable
    }
}