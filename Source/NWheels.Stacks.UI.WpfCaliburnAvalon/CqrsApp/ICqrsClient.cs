using System;
using System.Collections.Generic;
using NWheels.Processing;
using NWheels.Processing.Cqrs;

namespace NWheels.Stacks.UI.WpfCaliburnAvalon.CqrsApp
{
    public interface ICqrsClient
    {
        void Connect(string userName, string password);
        void Disconnect();
        void SendCommands(IList<ICqrsCommand> commands);
        event Action<CommandResult> Connected;
        event Action<CommandResult> Disconnected;
        event Action<IList<ICqrsEvent>> EventsReceived;
    }
}
