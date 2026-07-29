namespace GearShare.Api.Models;

public class GearItem
{
    public int Id { get; set; }

    public int OwnerId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public GearCategory Category { get; set; }

    public int DailyRateCents { get; set; }

    public GearStatus Status { get; set; }

    public DateTime CreatedAt { get; set; }
    public User Owner { get; set; } = null!;
    public ICollection<RentalRequest> RentalRequests { get; set; } = new List<RentalRequest>();
}