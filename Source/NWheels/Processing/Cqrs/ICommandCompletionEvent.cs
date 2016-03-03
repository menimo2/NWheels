namespace NWheels.Processing.Cqrs
{
    public interface ICommandCompletionEvent : ICqrsEvent
    {
        int CommandIndex { get; set; }
        CqrsCommandStatus Status { get; set; }
        string FaultCode { get; set; }
        string FaultSubCode { get; set; }
        string FaultReason { get; set; }
    }

    //---------------------------------------------------------------------------------------------------------------------------------------------------------

    public interface ICommandCompletionEvent<TResult> : ICommandCompletionEvent
    {
        TResult Result { get; set; }
    }
}
