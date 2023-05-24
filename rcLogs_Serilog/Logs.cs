using rcLogsBase;
using Serilog;
using Serilog.Core;
using System;

namespace rcLogs_Serilog
{
    public class Logs : ILogsBase
    {
        private static readonly Logger _loggerConsole;
        private static readonly Logger _loggerAll;
        private static readonly Logger _loggerImportant;
        private static readonly Logger _loggerMongo;
        private static readonly string _messageTemplate;

        static Logs()
        {
            _messageTemplate = "[serilog] {message}";

            _loggerConsole = new LoggerConfiguration()
                    .WriteTo.Console()
                    .CreateLogger();

            _loggerAll = new LoggerConfiguration()
                    .WriteTo.File(Settings.GetValue("file-log-all"))
                    .CreateLogger();

            _loggerImportant = new LoggerConfiguration()
                    .WriteTo.File(Settings.GetValue("file-log-important"))
                    .CreateLogger();

            _loggerMongo = new LoggerConfiguration()
                    .WriteTo.MongoDB(Settings.GetValue("mongodb"), Settings.GetValue("mongodb-collection"))
                    .CreateLogger();
        }

        //-- Information, Trace, Verbose, Debug
        public void LogInfo(string message)
        {
            _loggerConsole.Information(_messageTemplate, message);
            _loggerAll.Information(_messageTemplate, message);
            _loggerMongo.Information(_messageTemplate, message);
        }

        //-- Warning
        public void LogWarning(string message)
        {
            _loggerConsole.Warning(_messageTemplate, message);
            _loggerAll.Warning(_messageTemplate, message);
            _loggerImportant.Warning(_messageTemplate, message);
            _loggerMongo.Warning(_messageTemplate, message);
        }

        //-- Error, Critical, Fatal, Exception
        public void LogError(string message)
        {
            _loggerImportant.Error(_messageTemplate, message);
            _loggerMongo.Error(_messageTemplate, message);
        }

        public void LogError(Exception exception)
        {
            _loggerImportant.Error(exception, _messageTemplate, exception.Message);
            _loggerMongo.Error(exception, _messageTemplate, exception.Message);
        }

        public void LogError(string message, Exception exception)
        {
            _loggerImportant.Error(exception, _messageTemplate, message);
            _loggerMongo.Error(exception, _messageTemplate, message);
        }
    }
}
