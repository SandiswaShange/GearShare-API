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

        // We'll configure each entity here
    }
}