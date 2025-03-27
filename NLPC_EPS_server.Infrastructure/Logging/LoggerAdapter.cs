using Microsoft.Extensions.Logging;
using NLPC_EPS_server.Application.Contracts.Logging;

namespace NLPC_EPS_server.Infrastructure.Logging
{
    public class LoggerAdapter<T> : IAppLogger<T> where T : class
    {
        private readonly ILogger<T> _logger;
        public LoggerAdapter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<T>();
        }

        public void LogInformation(string message, params object[] args)
        {
            _logger.LogInformation(message, args);
        }

        public void LogWarning(string message, params object[] args)
        {
            _logger.LogWarning(message, args);
        }
    }
}
