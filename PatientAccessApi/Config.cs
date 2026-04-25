namespace PatientAccessApi
{
    public class Config
    {
        public bool? GenerateMockData { get; set; }
        public bool? EnableLogs { get; set; }
        public string? LogDirectory { get; set; }
        public string? ApiKey { get; set; }
    }
}
