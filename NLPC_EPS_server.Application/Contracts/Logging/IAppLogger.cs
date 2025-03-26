using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.Application.Contracts.Logging
{
    public interface IAppLogger<T> where T : class
    {
        void LogInformation(string messge, params object[] args);
        void LogWarning(string messge, params object[] args);
    }
}
