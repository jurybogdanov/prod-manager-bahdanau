using System;
using System.Collections.Generic;
using System.Text;

namespace ProductionManager.Services
{
    public interface ILoggerService
    {
        void LogError(string message, Exception exception);
        void LogInformation(string message);
    }
}
