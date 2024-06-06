namespace Kolos2_1.Entities;

public class ClientTrip
{
    public int IdClient { get; set; }
    public int IdTrip { get; set; }
    public DateTime RegisteredAt { get; set; }
    public DateTime? PaymentDate { get; set; }
    public virtual Client ClientNavigation { get; set; }
    public virtual Trip TripNavigation { get; set; }
}