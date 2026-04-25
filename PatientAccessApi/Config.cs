namespace PatientAccessApi
{
    /// <summary>
    /// Represents the application configuration settings bound from the <c>PatientAccessAPI</c> configuration section.
    /// </summary>
    public class Config
    {
        /// <summary>Gets or sets a value indicating whether mock patient data should be generated.</summary>
        public bool? GenerateMockData { get; set; }
        /// <summary>Gets or sets a value indicating whether application logging is enabled.</summary>
        public bool? EnableLogs { get; set; }
        /// <summary>Gets or sets the directory path where log files are written.</summary>
        public string? LogDirectory { get; set; }
        /// <summary>Gets or sets the API key used to authenticate incoming requests.</summary>
        public string? ApiKey { get; set; }
    }
}
