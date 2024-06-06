using Kolos2_1.DTOs;
using Kolos2_1.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Kolos2_1.Controller;

[ApiController]
[Route("api/[controller]")]
public class TripController : ControllerBase
{
    private readonly ITripService _tripService;

    public TripController(ITripService tripService)
    {
        _tripService = tripService;
    }

    [HttpGet]
    public async Task<IActionResult> GetInfo(CancellationToken token, int NumPage = 1, int pageSize = 10)
    {
        var (trips, counter) = await _tripService.GetTrips(token, NumPage, pageSize);
        int allPages = (int)System.Math.Ceiling(counter / (double)pageSize);
        return Ok(new
        {
            NumPage,
            pageSize,
            allPages,
            trips
            
        });
    }

    [HttpDelete("{ClientId}")]
    public async Task<IActionResult> DelClient(CancellationToken token, int ClientId)
    {
        string res = await _tripService.DeleteClient(token, ClientId);
        if (res.StartsWith("Error"))
        {
            return NotFound(res);
        }

        return Ok(res);
    }

    [HttpPost]
    public async Task<IActionResult> AddClientToTrip(CancellationToken token, ClientAddingDTO dto)
    {
        string res = await _tripService.AddClientToTrip(token, dto);

        if (res.StartsWith("Error"))
        {
            return NotFound(res);
        }

        return Ok(res);
    }
}