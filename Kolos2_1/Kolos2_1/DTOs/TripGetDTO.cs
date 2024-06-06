namespace Kolos2_1.DTOs;

public class TripGetDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public int MaxPeople { get; set; }
    public List<CountryGetDTO> Countries { get; set; }
    public List<ClientGetDTO> Clients { get; set; }
    
}