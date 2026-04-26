namespace PatientAccessApi.Endpoints.Responses
{
    /// <summary>
    /// Represents a response returned when a request fails.
    /// </summary>
    [Serializable]
    public record FailResponse : IResponse
    {
        /// <summary>Gets or sets a value indicating whether the request was successful. Always <c>false</c> for a fail response.</summary>
        public bool Success { get; set; } = false;
        /// <summary>Gets or sets a message describing the error that occurred.</summary>
        public string? ErrorMessage { get; set; }
    }
}
