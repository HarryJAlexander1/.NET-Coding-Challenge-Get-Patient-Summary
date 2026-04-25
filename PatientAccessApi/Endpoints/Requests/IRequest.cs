namespace PatientAccessApi.Endpoints.Requests
{
    /// <summary>
    /// Defines the contract for an API request.
    /// </summary>
    internal interface IRequest
    {
        /// <summary>Gets or sets the user ID associated with the request.</summary>
        int UserId { get; set; }
    }
}
