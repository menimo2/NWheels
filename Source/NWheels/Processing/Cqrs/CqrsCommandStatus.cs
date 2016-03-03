namespace NWheels.Processing.Cqrs
{
    public enum CqrsCommandStatus
    {
        Completed,
        Failed,
        TimedOut,
        Cancelled
    }
}