namespace GearShare.Api.Exceptions;

public class GearNotFoundException : Exception
{
    public GearNotFoundException(int gearId)
        : base($"Gear item {gearId} was not found.")
    {
    }
}