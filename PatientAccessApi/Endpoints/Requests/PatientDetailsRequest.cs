namespace PatientAccessApi.Endpoints.Requests
{
    /// <summary>
    /// Represents a request to retrieve details for a specific patient.
    /// </summary>
    [Serializable]
    internal record PatientDetailsRequest : IRequest
    {
        /// <summary>Gets or sets the unique user ID of the patient to retrieve.</summary>
        public int UserId { get; set; }
    }
}
