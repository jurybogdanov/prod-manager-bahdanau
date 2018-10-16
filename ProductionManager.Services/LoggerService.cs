using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace ProductionManager.Services
{
    public class LoggerService: ILoggerService
    {
        private readonly ILogger _logger;

        public LoggerService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("Productin Manager logger");
        }

        public void LogError(string message, Exception exception)
        {
            _logger.LogError(exception, message);
        }

        public void LogInformation(string message)
        {
            _logger.LogInformation(message);
        }
    }
}
