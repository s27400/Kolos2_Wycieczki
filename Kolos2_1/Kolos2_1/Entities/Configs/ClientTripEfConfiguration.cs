using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kolos2_1.Entities.Configs;

public class ClientTripEfConfiguration : IEntityTypeConfiguration<ClientTrip>
{
    public void Configure(EntityTypeBuilder<ClientTrip> builder)
    {
        builder.HasKey(ct => new { ct.IdClient, ct.IdTrip }).HasName("ClientTrip_pk");

        builder.HasOne(ct => ct.ClientNavigation)
            .WithMany(ct => ct.ClientTrips)
            .HasForeignKey(ct => ct.IdClient)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ct => ct.TripNavigation)
            .WithMany(ct => ct.ClientTrip)
            .HasForeignKey(ct => ct.IdClient)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(ct => ct.RegisteredAt).IsRequired();
        builder.Property(ct => ct.PaymentDate);

        builder.ToTable("Client_Trip");

        ClientTrip[] clientTrips =
        {
            new ClientTrip()
            {
                IdClient = 1, IdTrip = 1, RegisteredAt = DateTime.Now, PaymentDate = null
            },
            new ClientTrip()
            {
                IdClient = 2, IdTrip = 2, RegisteredAt = DateTime.Now, PaymentDate = DateTime.Now.AddMinutes(1)
            }
        };

        builder.HasData(clientTrips);
    }
}