using PatientAccessApi.Data;

namespace PatientAccessApi.Endpoints.Responses
{
    [Serializable]
    public record PatientDetailsResponse : IResponse
    {
        public Patient? Patient { get; set; }
        public bool Success { get; set; }
    }
}
