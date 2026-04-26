using Microsoft.Extensions.Options;

namespace PatientAccessApi.Log
{
    /// <summary>
    /// Represents a log entry containing a message, severity level, and caller information.
    /// </summary>
    public class Log : ILog
    {
        /// <summary>Gets or sets the data payload of the log entry.</summary>
        public object Data { get; set; }
        /// <summary>Gets or sets the severity level of the log entry.</summary>
        public LogLevel Level { get; set; }
        /// <summary>Gets or sets the name of the member that created the log entry.</summary>
        public string Caller { get; set; }

        /// <summary>
        /// Initialises a new instance of <see cref="Log"/>.
        /// </summary>
        /// <param name="logData">The data or message to log.</param>
        /// <param name="logLevel">The severity level of the log entry.</param>
        /// <param name="caller">The name of the calling member, populated automatically.</param>
        internal Log(object logData, LogLevel logLevel, [System.Runtime.CompilerServices.CallerMemberName] string caller = "")
        {
            Data = logData;
            Level = logLevel;
            Caller = caller;
        }
    }

    /// <summary>
    /// Handles writing log entries to the application log file.
    /// </summary>
    public class LogHandler
    {
        private readonly string _logDirectory;
        private readonly Config _config;
        /// <summary>
        /// Initialises a new instance of <see cref="LogHandler"/>.
        /// </summary>
        /// <param name="config">The application configuration containing the log directory path.</param>
        public LogHandler(IOptions<Config> config)
        {
            _logDirectory = config.Value.LogDirectory ?? ".\\systemlogs";
            _config = config.Value;
        }
        /// <summary>
        /// Writes a log entry to the application log file.
        /// </summary>
        /// <param name="log">The log entry to write.</param>
        internal void WriteLog(Log log)
        {
            if (_config.EnableLogs == null || !_config.EnableLogs.Value)
                return;

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
