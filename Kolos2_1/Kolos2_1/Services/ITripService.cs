using Kolos2_1.DTOs;
using Kolos2_1.Repositories;

namespace Kolos2_1.Services;

public interface ITripService
{
    public Task<(IEnumerable<TripGetDTO>, int)> GetTrips(CancellationToken token, int NumPage, int pageSize);
    public Task<string> DeleteClient(CancellationToken token, int ClientId);

    public Task<string> AddClientToTrip(CancellationToken token, ClientAddingDTO dto);

}