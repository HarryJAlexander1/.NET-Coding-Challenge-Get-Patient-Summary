namespace PatientAccessApi.Endpoints.Responses
{
    /// <summary>
    /// Defines the contract for an API response.
    /// </summary>
    public interface IResponse
    {
        /// <summary>Gets or sets a value indicating whether the request was successful.</summary>
        bool Success { get; set; }
    }
}
