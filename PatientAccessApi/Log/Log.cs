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

    internal class LogHandler
    {
        private readonly string _logDirectory;
        internal LogHandler(string logDirectory)
        {
            _logDirectory = logDirectory;
        }
        internal void WriteLog(Log log)
        {
            var logFilePath = Path.Combine(_logDirectory, "application.log");
            var logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{log.Level}] {log.Data} (Caller: {log.Caller})";
            File.AppendAllText(logFilePath, logEntry + Environment.NewLine);
        }
    }
}
