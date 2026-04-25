namespace PatientAccessApi.Log
{
    public interface ILog
    { 
        internal object Data { get; set; }
        internal string Caller { get; set; }
        internal LogLevel Level { get; set; }
    }

    public enum LogLevel
    {
        Info,
        Warning,
        Error
    }
}
