using System.ComponentModel.DataAnnotations;

namespace GearShare.Api.DTOs;

public class CreateRentalRequestDto
{
    [Required]
    [EmailAddress]
    public string RenterEmail { get; set; } = string.Empty;

    [Required]
    public string RenterName { get; set; } = string.Empty;

    [Required]
    [MinLength(10)]
    public string RenterPhone { get; set; } = string.Empty;

    [Required]
    public DateOnly StartDate { get; set; }

    [Required]
    public DateOnly EndDate { get; set; }

    public string? Notes { get; set; }
}