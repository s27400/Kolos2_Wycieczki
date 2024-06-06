using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kolos2_1.Entities.Configs;

public class ClientEfConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasKey(c => c.IdClient).HasName("IdClient");
        builder.Property(c => c.IdClient).UseIdentityColumn();

        builder.Property(c => c.FirstName).IsRequired().HasMaxLength(120);
        builder.Property(c => c.LastName).IsRequired().HasMaxLength(120);
        builder.Property(c => c.Email).IsRequired().HasMaxLength(120);
        builder.Property(c => c.Telephone).IsRequired().HasMaxLength(120);
        builder.Property(c => c.Pesel).IsRequired().HasMaxLength(120);

        builder.ToTable("Client");

        Client[] clients =
        {
            new Client()
            {
                IdClient = 1, FirstName = "Ada", LastName = "Nowak", Email = "a@wp.pl", Pesel = "1", Telephone = "123"
            },
            new Client()
            {
                IdClient = 2, FirstName = "Adam", LastName = "Malinowski", Email = "m@wp.pl", Pesel = "2",
                Telephone = "312"
            }
        };

        builder.HasData(clients);
    }
}