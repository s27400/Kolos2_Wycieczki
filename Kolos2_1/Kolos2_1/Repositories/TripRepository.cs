using Kolos2_1.DTOs;
using Kolos2_1.Entities;
using Kolos2_1.Entities.Configs;
using Microsoft.EntityFrameworkCore;

namespace Kolos2_1.Repositories;

public class TripRepository : ITripRepository
{
    private readonly TravelDbContext _context;

    public TripRepository(TravelDbContext context)
    {
        _context = context;
    }

    public async Task<(IEnumerable<TripGetDTO>, int)> GetAllInformations(CancellationToken token, int numPage, int pageSize)
    {

        var trips = _context.Trips
            .Include(t => t.ClientTrip)
            .ThenInclude(ct => ct.ClientNavigation)
            .Include(t => t.IdCountries)
            .OrderByDescending(x => x.DateFrom);

        int counter = await trips.CountAsync(token);

        var final = await trips
            .Skip((numPage - 1) * pageSize)
            .Take(pageSize)
            .Select(t => new TripGetDTO()
            {
                Name = t.Name,
                Description = t.Description,
                DateFrom = t.DateFrom,
                DateTo = t.DateTo,
                MaxPeople = t.MaxPeople,
                Countries = t.IdCountries.Select(c => new CountryGetDTO()
                {
                    Name = c.Name
                }).ToList(),
                Clients = t.ClientTrip.Select(cl => new ClientGetDTO()
                {
                    FirstName = cl.ClientNavigation.FirstName,
                    LastName = cl.ClientNavigation.LastName
                }).ToList()
            }).ToListAsync(token);

        return (final, counter);
    }


    public async Task<bool> toDelete(CancellationToken token, int ClientId)
    {
        var clientTrips = await _context.ClientTrips
            .Where(x => x.IdClient == ClientId)
            .CountAsync(token);
        
        if (clientTrips > 0)
        {
            return false;
        }

        return true;

    }

    public async Task<string> DeleteClient(CancellationToken token, int ClientId)
    {
        var toDel = await _context.Clients
            .FirstOrDefaultAsync(x => x.IdClient == ClientId, token);
        _context.Clients.Remove(toDel);
        await _context.SaveChangesAsync(token);
        return "Usunieto";
    }

    public async Task<string> AddClientToTripRepo(CancellationToken token, ClientAddingDTO dto)
    {
        var peselVerify = await _context.Clients
            .FirstOrDefaultAsync(x => x.Pesel == dto.Pesel, token);

        if (peselVerify == null)
        {
            return "Error: Klient o takim pesel nie istnieje";
        }

        var tripDate = await  _context.Trips
            .FirstOrDefaultAsync(x => x.IdTrip == dto.IdTrip && x.Name == dto.TripName, token);

        if (tripDate == null)
        {
            return "Error Taka wycieczka nie istnieje";
        }

        var signedUp = await _context.ClientTrips
            .FirstOrDefaultAsync(x => x.IdClient == peselVerify.IdClient && x.IdTrip == dto.IdTrip, token);

        if (signedUp != null)
        {
            return "Error: klient jest juz zapisany na ta wycieczke";
        }

        if (tripDate.DateFrom < DateTime.Now)
        {
            return "Error Wycieczka juz sie odbyla";
        }

        _context.ClientTrips.Add(new ClientTrip()
        {
            IdClient = peselVerify.IdClient,
            IdTrip = dto.IdTrip,
            PaymentDate = dto.PaymentDate,
            RegisteredAt = DateTime.Now
        });

        await _context.SaveChangesAsync(token);

        return "Dodano klienta do podanej podrozy";



    }

}