using GearShare.Api.DTOs;
using GearShare.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GearShare.Api.Data;

public class GearShareDbContext : DbContext
{
    public GearShareDbContext(DbContextOptions<GearShareDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();

    public DbSet<GearItem> GearItems => Set<GearItem>();

    public DbSet<RentalRequestResponseDto> RentalRequests => Set<RentalRequestResponseDto>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //user config
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(u => u.Id);

            entity.Property(u => u.Email).IsRequired().HasMaxLength(255);

            entity.Property(u => u.PasswordHash).IsRequired().HasMaxLength(255);

            entity.Property(u => u.Name).IsRequired().HasMaxLength(100);

            entity.Property(u => u.Role).HasConversion<string>().IsRequired();
        });
        //gearitem config
        modelBuilder.Entity<GearItem>(entity =>
        {
            entity.HasKey(g => g.Id);

            entity.Property(g => g.Title).IsRequired().HasMaxLength(150);

            entity.Property(g => g.Description).HasMaxLength(1000);

            entity.Property(g => g.Category).HasConversion<string>().IsRequired();

            entity.Property(g => g.Status).HasConversion<string>().IsRequired();

            entity.Property(g => g.DailyRateCents).IsRequired();

            entity.Property(g => g.CreatedAt).IsRequired();

            entity.HasOne<User>().WithMany().HasForeignKey(g => g.OwnerId).OnDelete(DeleteBehavior.Restrict);
        });

        //rentalrequest config
        modelBuilder.Entity<RentalRequest>(entity =>
        {
            entity.HasKey(r => r.Id);

            entity.Property(r => r.RenterName).IsRequired().HasMaxLength(100);

            entity.Property(r => r.RenterEmail).IsRequired().HasMaxLength(255);

            entity.Property(r => r.RenterPhone).IsRequired().HasMaxLength(30);

            entity.Property(r => r.Status).HasConversion<string>().IsRequired();

            entity.Property(r => r.Notes).HasMaxLength(1000);

            entity.Property(r => r.RequestedAt).IsRequired();

            entity.HasOne<GearItem>().WithMany().HasForeignKey(r => r.GearItemId).OnDelete(DeleteBehavior.Cascade);
        });
    }
}