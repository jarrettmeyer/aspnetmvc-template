using System;

namespace Project.Core.Lib.Infrastructure
{
    public interface ILogger
    {
        void WriteDebugMessage(string message);
        void WriteDebugMessage(string message, Exception exception);
        void WriteErrorMessage(string message);
        void WriteErrorMessage(string message, Exception exception);
        void WriteFatalMessage(string message);
        void WriteFatalMessage(string message, Exception exception);
        void WriteInfoMessage(string message);
        void WriteInfoMessage(string message, Exception exception);
        void WriteWarningMessage(string message);
        void WriteWarningMessage(string message, Exception exception);
    }
}
