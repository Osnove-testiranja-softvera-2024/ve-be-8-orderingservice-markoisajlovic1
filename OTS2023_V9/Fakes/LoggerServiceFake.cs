using OTS2023_V9.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS2023_V9.Fakes
{
    public class LoggerServiceFake : ILoggerService
    {
        public string lastError;

        public void LogError(string message)
        {
            lastError = message;  
        }
    }
}
