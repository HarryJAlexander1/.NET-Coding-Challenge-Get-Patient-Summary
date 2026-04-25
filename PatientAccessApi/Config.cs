namespace PatientAccessApi
{
    internal class Config
    {
        internal bool? GenerateMockData { get; set; }
        internal bool? EnableLogs { get; set; }
        internal string? LogDirectory { get; set; }
        internal string? APIKey { get; set; }
    }
}
