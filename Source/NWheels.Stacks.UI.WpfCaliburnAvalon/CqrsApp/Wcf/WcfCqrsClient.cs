using System;
using System.Collections.Generic;
using NWheels.Processing;
using NWheels.Processing.Cqrs;

namespace NWheels.Stacks.UI.WpfCaliburnAvalon.CqrsApp.Wcf
{
    class WcfCqrsClient : ICqrsClient
    {
        #region Implementation of ICqrsClient

        public void Connect(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public void Disconnect()
        {
            throw new NotImplementedException();
        }

        public void SendCommands(IList<ICqrsCommand> commands)
        {
            throw new NotImplementedException();
        }

        public event Action<CommandResult> Connected;
        public event Action<CommandResult> Disconnected;
        public event Action<IList<ICqrsEvent>> EventsReceived;

        #endregion

        protected void OnConnected()
        {
            Connected(null);
        }
        protected void OnDisconnected()
        {
            Disconnected(null);
        }
        protected void OnEventsReceived()
        {
            EventsReceived(null);
        }
    }
}
