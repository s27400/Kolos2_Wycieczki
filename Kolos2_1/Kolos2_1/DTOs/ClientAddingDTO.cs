using System.ComponentModel.DataAnnotations;

namespace Kolos2_1.DTOs;

public class ClientAddingDTO
{
    [Required]
    [MaxLength(120)]
    public string FirstName { get; set; }
    [Required]
    [MaxLength(120)]
    public string LastName { get; set; }
    [Required]
    [MaxLength(120)]
    public string Email { get; set; }
    [Required]
    [MaxLength(120)]
    public string Telephone { get; set; }
    [Required]
    [MaxLength(120)]
    public string Pesel { get; set; }
    [Required]
    public int IdTrip { get; set; }
    [Required]
    [MaxLength(120)]
    public string TripName { get; set; }
    public Nullable<DateTime> PaymentDate { get; set; }
}