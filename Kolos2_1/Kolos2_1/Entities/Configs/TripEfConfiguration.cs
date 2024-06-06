using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kolos2_1.Entities.Configs;

public class TripEfConfiguration : IEntityTypeConfiguration<Trip>
{
    public void Configure(EntityTypeBuilder<Trip> builder)
    {
        builder.HasKey(t => t.IdTrip).HasName("IdTrip");
        builder.Property(t => t.IdTrip).UseIdentityColumn();

        builder.Property(t => t.Name).IsRequired().HasMaxLength(120);
        builder.Property(t => t.Description).IsRequired().HasMaxLength(220);
        builder.Property(t => t.DateFrom).IsRequired();
        builder.Property(t => t.DateTo).IsRequired();
        builder.Property(t => t.MaxPeople).IsRequired();

        builder.ToTable("Trip");

        Trip[] trips =
        {
            new Trip()
            {
                IdTrip = 1, Name = "Maroko", Description = "Desc1", DateFrom = DateTime.Now.AddMonths(2),
                DateTo = DateTime.Now.AddMonths(3), MaxPeople = 120
            },
            new Trip()
            {
                IdTrip = 2, Name = "USA", Description = "Desc2", DateFrom = DateTime.Now.AddMinutes(2),
                DateTo = DateTime.Now.AddMinutes(6), MaxPeople = 90
            },
        };

        builder.HasData(trips);
    }
}