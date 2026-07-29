using GearShare.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace GearShare.Api.Controllers;

[ApiController]
[Route("api/gear")]
public class GearController : ControllerBase
{
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
}