namespace GearShare.Api.Exceptions;

public class GearNotAvailableException : Exception
{
    public GearNotAvailableException(int gearId)
        : base($"Gear item {gearId} is not available for rental.")
    {
    }
}