namespace NWheels.Processing.Cqrs
{
    public interface ICqrsCommand
    {
        int Index { get; set; }
        bool ShouldNotifyCompletion { get; set; }
    }
}
