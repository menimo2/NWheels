using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWheels.Processing.Cqrs
{
    public class CqrsSession
    {
        private readonly ConcurrentDictionary<int, CqrsPromise> _resultByCommandIndex;
        private readonly ICqrsClient _clientApi;
        private int _commandIndex = 0;

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        public CqrsSession(ICqrsClient client)
        {
            _resultByCommandIndex = new ConcurrentDictionary<int, CqrsPromise>();
            _clientApi = client;


        }
    }
}
