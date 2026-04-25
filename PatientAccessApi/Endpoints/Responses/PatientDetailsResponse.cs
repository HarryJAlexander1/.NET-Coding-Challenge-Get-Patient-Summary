namespace PatientAccessApi.Endpoints.Responses
{
    [Serializable]
    public record PatientDetailsResponse : IResponse
    {
        public int UserId { get; set; }
        public int NHSNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? GPPractice { get; set; }
    }
}
