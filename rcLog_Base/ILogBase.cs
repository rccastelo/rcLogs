using System;

namespace rcLog_Base
{
    public interface ILogBase
    {
        void LogInfo(string message);
        void LogWarning(string message);
        void LogError(string message);
        void LogError(Exception exception);
        void LogError(string message, Exception exception);
    }
}
