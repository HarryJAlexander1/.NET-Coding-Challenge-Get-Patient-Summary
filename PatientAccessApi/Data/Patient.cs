namespace PatientAccessApi.Data
{
    public record Patient
    {
        public int UserId { get; set; }
        public int NHSNumber { get; set; }
        public string? Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? GPPractice { get; set; }
    }
}
