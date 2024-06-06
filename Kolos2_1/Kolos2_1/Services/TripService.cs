using Kolos2_1.DTOs;
using Kolos2_1.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Kolos2_1.Services;

public class TripService : ITripService
{
    private readonly ITripRepository _tripRepository;

    public TripService(ITripRepository tripRepository)
    {
        _tripRepository = tripRepository;
    }

    public async Task<(IEnumerable<TripGetDTO>, int)> GetTrips(CancellationToken token, int NumPage = 1, int pageSize = 10)
    {
        return await _tripRepository.GetAllInformations(token, NumPage, pageSize);
    }

    public async Task<string> DeleteClient(CancellationToken token, int ClientId)
    {
        bool verify = await _tripRepository.toDelete(token, ClientId);

        if (verify)
        {
            string res = await _tripRepository.DeleteClient(token, ClientId);
            return res + " Klienta o id: " + ClientId;
        }

        return "Error: Klient bierze udzial w wycieczach";
    }

    public async Task<string> AddClientToTrip(CancellationToken token, ClientAddingDTO dto)
    {
        return await _tripRepository.AddClientToTripRepo(token, dto);
    }

}