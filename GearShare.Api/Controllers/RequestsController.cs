using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GearShare.Api.Controllers;

[ApiController]
[Route("api/requests")]
public class RequestsController : ControllerBase
{
    [Authorize]
    [HttpPatch("{id:int}/status")]
    public async Task<IActionResult> UpdateStatus(
        int id,
        [FromBody] string newStatus)
    {
        await Task.CompletedTask;

        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var isAdmin = User.IsInRole("Admin");

        // TODO:
        // Load RentalRequest
        // Load GearItem
        // Compare GearItem.OwnerId with authenticated user
        // If owner OR admin -> update status
        // Otherwise:

        if (!isAdmin)
        {
            //Not 401, because the user is already authenticated.
            return Forbid();
        }

        return NoContent();
    }
}