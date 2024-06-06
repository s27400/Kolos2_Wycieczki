using Kolos2_1.DTOs;

namespace Kolos2_1.Repositories;

public interface ITripRepository
{
    public Task<(IEnumerable<TripGetDTO>, int)> GetAllInformations(CancellationToken token, int NumPage, int pageSize);

    public Task<bool> toDelete(CancellationToken token, int ClientId);
    public Task<string> DeleteClient(CancellationToken token, int ClientId);
    
    public Task<string> AddClientToTripRepo(CancellationToken token, ClientAddingDTO dto);

}