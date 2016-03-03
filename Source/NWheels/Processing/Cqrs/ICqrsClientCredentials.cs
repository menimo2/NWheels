using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWheels.Processing.Cqrs
{
    public interface ICqrsClientCredentials
    {
    }

    //---------------------------------------------------------------------------------------------------------------------------------------------------------

    public interface IUsernamePasswordCredentials : ICqrsClientCredentials
    {
        string UserName { get; set; }
        string Password { get; set; }
    }
}
