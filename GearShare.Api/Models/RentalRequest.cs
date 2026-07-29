namespace GearShare.Api.Models;

public class RentalRequest
{
    public int Id { get; set; }

    public int GearItemId { get; set; }

    public string RenterName { get; set; } = string.Empty;

    public string RenterEmail { get; set; } = string.Empty;

    public string RenterPhone { get; set; } = string.Empty;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public RentalRequestStatus Status { get; set; }

    public string? Notes { get; set; }

    public DateTime RequestedAt { get; set; }
}