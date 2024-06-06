namespace Kolos2_1.Entities;

public class Trip
{
    public int IdTrip { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public int MaxPeople { get; set; }
    public virtual ICollection<Country> IdCountries { get; set; } = new List<Country>();
    public virtual ICollection<ClientTrip> ClientTrip { get; set; } = new List<ClientTrip>();
}