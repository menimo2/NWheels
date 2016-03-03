using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWheels.Processing.Cqrs
{
    public interface ICqrsPromise
    {
        ICqrsPromise OnCompleted(Action handler);
        ICqrsPromise OnFailed(Action handler);
        ICqrsPromise OnCancelled(Action handler);
        ICqrsPromise OnTimedOut(Action handler);
    }
}
