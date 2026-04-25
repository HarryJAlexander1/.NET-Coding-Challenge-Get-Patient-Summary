using PatientAccessApi.Data;

namespace PatientAccessApi.Endpoints.Responses
{
    /// <summary>
    /// Represents the response returned when patient details are successfully retrieved.
    /// </summary>
    [Serializable]
    public record PatientDetailsResponse : IResponse
    {
        /// <summary>Gets or sets the retrieved patient details.</summary>
        public Patient? Patient { get; set; }
        /// <summary>Gets or sets a value indicating whether the request was successful.</summary>
        public bool Success { get; set; }
    }
}
