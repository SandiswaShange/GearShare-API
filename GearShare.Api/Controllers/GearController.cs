using GearShare.Api.Models;
using Microsoft.AspNetCore.Mvc;
using GearShare.Api.DTOs;
using Microsoft.Extensions.Caching.Memory;

namespace GearShare.Api.Controllers;

[ApiController]
[Route("api/gear")]
public class GearController : ControllerBase
{

//add memory caching
    private readonly IMemoryCache _cache;
    
        public GearController(IMemoryCache cache)
        {
            _cache = cache;
        }
    private static readonly List<GearItem> Gear =
    [
        new() { Id = 1, Title = "Camping Tent", Description = "4-person tent" },
        new() { Id = 2, Title = "Kayak", Description = "Single-person kayak" }
    ];

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GearItem>>> GetAll()
    {
        await Task.CompletedTask;
        return Ok(Gear);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<GearItem>> GetById(int id)
    {
        await Task.CompletedTask;

        var item = Gear.FirstOrDefault(g => g.Id == id);

        if (item is null)
        {
            return Problem(
                title: "Gear item not found",
                detail: $"No gear item exists with id {id}.",
                statusCode: StatusCodes.Status404NotFound);
        }

        return Ok(item);
    }

    [HttpGet("{id:int}/requests")]
    public async Task<ActionResult<IEnumerable<object>>> GetRequests(int id)
    {
        await Task.CompletedTask;

        return Ok(Array.Empty<object>());
    }

//add a endpoint to creat a  rental request
    [HttpPost("{gearItemId:int}/requests")]
    public async Task<ActionResult<RentalRequestResponseDto>> CreateRentalRequest(
        int gearItemId,
        [FromBody] CreateRentalRequestDto dto,
        [FromHeader(Name = "Idempotency-Key")] string? idempotencyKey)
    {
        await Task.CompletedTask;

        // Validation
        // Business rules
        // Idempotency
        // Mapping
        // Return Created(...)

        return StatusCode(StatusCodes.Status501NotImplemented);
    }
}