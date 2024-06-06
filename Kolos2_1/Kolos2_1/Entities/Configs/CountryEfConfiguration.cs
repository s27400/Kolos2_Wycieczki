using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kolos2_1.Entities.Configs;

public class CountryEfConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.HasKey(c => c.IdCountry).HasName("IdCountry");
        builder.Property(c => c.IdCountry).UseIdentityColumn();
        builder.Property(c => c.Name).IsRequired().HasMaxLength(120);

        builder.ToTable("Country");

        Country[] countries = new[]
        {
            new Country()
            {
                IdCountry = 1, Name = "Maroko_kraj"
            },
            new Country()
            {
                IdCountry = 2, Name = "USA_kraj"
            }
        };
        builder.HasData(countries);

        builder.HasMany(c => c.IdTrips)
            .WithMany(t => t.IdCountries)
            .UsingEntity<Dictionary<string, object>>(
                "CountryTrip",
                j => j.HasOne<Trip>().WithMany().HasForeignKey("IdTrip"),
                j => j.HasOne<Country>().WithMany().HasForeignKey("IdCountry"))
            .HasData(
                new { IdCountry = 1, IdTrip = 1 },
                new { IdCountry = 2, IdTrip = 2 });
    }
}