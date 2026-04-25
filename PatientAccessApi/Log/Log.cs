using Microsoft.Extensions.Options;

namespace PatientAccessApi.Log
{
    public class Log : ILog
    {
        public object Data { get; set; }
        public LogLevel Level { get; set; }
        public string Caller { get; set; }

        internal Log(object logData, LogLevel logLevel, [System.Runtime.CompilerServices.CallerMemberName] string caller = "")
        {
            Data = logData;
            Level = logLevel;
            Caller = caller;
        }
    }

    public class LogHandler
    {
        private readonly string _logDirectory;
        public LogHandler(IOptions<Config> config)
        {
            _logDirectory = config.Value.LogDirectory ?? ".\\systemlogs";
        }
        internal void WriteLog(Log log)
        {
            var logFilePath = Path.Combine(_logDirectory, "application.log");
            var logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{log.Level}] \"{log.Data}\" (Caller: {log.Caller})";

            if (!Directory.Exists(_logDirectory))
            {
                Directory.CreateDirectory(_logDirectory);
            }

            File.AppendAllText(logFilePath, logEntry + Environment.NewLine);
        }
    }
}
