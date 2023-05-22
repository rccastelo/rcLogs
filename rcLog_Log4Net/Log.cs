using rcLog_Base;
using System;
using System.IO;

namespace rcLog_Log4Net
{
    public class Log : ILogBase
    {
        private static readonly log4net.ILog _logger;

        static Log()
        {
            FileInfo fi = Settings.GetSettingsFile();

            log4net.Config.XmlConfigurator.ConfigureAndWatch(fi);

            _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        //-- Info, Trace, Verbose, Debug
        public void LogInfo(string message)
        {
            _logger.Info(message);
        }

        //-- Warning
        public void LogWarning(string message)
        {
            _logger.Warn(message);
        }

        //-- Error, Critical, Fatal, Exception
        public void LogError(string message)
        {
            _logger.Error(message);
        }

        public void LogError(Exception exception)
        {
            _logger.Error(exception.Message, exception);
        }

        public void LogError(string message, Exception exception)
        {
            _logger.Error(message, exception);
        }
    }
}
