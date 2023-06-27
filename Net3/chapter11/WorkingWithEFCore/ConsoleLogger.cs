using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Packt.Shared
{
    public class ConsoleLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return  new ConsoleLogger();
        }

        public void Dispose()
        {
            
        }
    }

    public class ConsoleLogger : ILogger
    {
        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            switch(logLevel)
            {
                case LogLevel.Trace:
                case LogLevel.Information:
                case LogLevel.None:
                    return false;
                case LogLevel.Debug:
                case LogLevel.Warning:
                case LogLevel.Error:
                case LogLevel.Critical:
                default:
                    return true;
            }
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            // log the level and event identifier 
            WriteLine($"Level: {logLevel}, Event ID: {eventId.Id}");

            // only output the state or exception if it exists 
            if (state != null) {
                Write($"State: {state}");
            }  
            
            if (exception != null) {
                Write($"Exception : {exception}");
            }

            WriteLine();
        }
    }
}
