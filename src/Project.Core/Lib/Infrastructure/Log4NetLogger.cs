using System;
using log4net;

namespace Project.Core.Lib.Infrastructure
{
    public class Log4NetLogger : ILogger
    {
        private readonly ILog _logger;

        public Log4NetLogger(Type type)
        {
            _logger = LogManager.GetLogger(type);
        }

        public void WriteDebugMessage(string message)
        {
            _logger.Debug(message);
        }

        public void WriteDebugMessage(string message, Exception exception)
        {
            _logger.Debug(message, exception);
        }

        public void WriteErrorMessage(string message)
        {
            _logger.Error(message);
        }

        public void WriteErrorMessage(string message, Exception exception)
        {
            _logger.Error(message, exception);
        }

        public void WriteFatalMessage(string message)
        {
            _logger.Fatal(message);
        }

        public void WriteFatalMessage(string message, Exception exception)
        {
            _logger.Fatal(message, exception);
        }

        public void WriteInfoMessage(string message)
        {
            _logger.Info(message);
        }

        public void WriteInfoMessage(string message, Exception exception)
        {
            _logger.Info(message, exception);
        }

        public void WriteWarningMessage(string message)
        {
            _logger.Warn(message);
        }

        public void WriteWarningMessage(string message, Exception exception)
        {
            _logger.Warn(message, exception);
        }
    }
}
