namespace PatientAccessApi.Log
{
    /// <summary>
    /// Defines the contract for a log entry.
    /// </summary>
    public interface ILog
    { 
        /// <summary>Gets or sets the data payload of the log entry.</summary>
        internal object Data { get; set; }
        /// <summary>Gets or sets the name of the member that created the log entry.</summary>
        internal string Caller { get; set; }
        /// <summary>Gets or sets the severity level of the log entry.</summary>
        internal LogLevel Level { get; set; }
    }

    /// <summary>
    /// Represents the severity level of a log entry.
    /// </summary>
    public enum LogLevel
    {
        /// <summary>Informational message.</summary>
        Info,
        /// <summary>Warning message indicating a potential issue.</summary>
        Warning,
        /// <summary>Error message indicating a failure.</summary>
        Error
    }
}
