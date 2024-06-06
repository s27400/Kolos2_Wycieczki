using Kolos2_1.Entities.Configs;
using Microsoft.EntityFrameworkCore;

namespace Kolos2_1.Entities;

public class TravelDbContext : DbContext
{
    public virtual DbSet<Client> Clients { get; set; }
    public virtual DbSet<ClientTrip> ClientTrips { get; set; }
    public virtual DbSet<Country> Countries { get; set; }
    public virtual DbSet<Trip> Trips { get; set; }

    public TravelDbContext()
    {
    }

    public TravelDbContext(DbContextOptions<TravelDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClientEfConfiguration).Assembly);
    }
    
    
}