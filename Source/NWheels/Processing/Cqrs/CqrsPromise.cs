using System;

namespace NWheels.Processing.Cqrs
{
    public class CqrsPromise
    {
        private readonly Action<CqrsPromise> _onCompleted;

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        internal CqrsPromise(ICqrsCommand command, Action<CqrsPromise> onCompleted)
        {
            Command = command;
            _onCompleted = onCompleted;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        public ICqrsCommand Command { get; private set; }
        public ICommandCompletionEvent Completion { get; private set; }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        internal void NotifyCompleted(ICommandCompletionEvent completionEvent)
        {
            this.Completion = completionEvent;

            if (_onCompleted != null)
            {
                _onCompleted(this);
            }
        }
    }
}
