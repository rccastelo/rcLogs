using rcLogsBase;
using System;
using System.IO;

namespace rcLogs_Log4Net
{
    public class Logs : ILogsBase
    {
        private static readonly log4net.ILog _logger;

        static Logs()
        {
            FileInfo fi = Settings.GetFileSettings();

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
