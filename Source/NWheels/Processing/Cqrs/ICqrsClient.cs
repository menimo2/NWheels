using System;
using System.Collections.Generic;

namespace NWheels.Processing.Cqrs
{
    public interface ICqrsClient
    {
        void Connect(ICqrsClientCredentials credentials);
        void Disconnect();
        CqrsPromise SendCommand(ICqrsCommand command, TimeSpan? timeout = null);
        event EventHandler<CqrsPromise> Connected;
        event EventHandler<CqrsPromise> ConnectFailed;
        event EventHandler<CqrsPromise> Disconnected;
        event EventHandler<IList<ICqrsEvent>> EventsReceived;
    }
}
