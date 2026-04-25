namespace PatientAccessApi.Endpoints.Responses
{
    [Serializable]
    public record FailResponse : IResponse
    {
        public bool Success { get; set; } = false;
        public string? ErrorMessage { get; set; }
    }
}
