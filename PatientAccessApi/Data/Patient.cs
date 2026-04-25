namespace PatientAccessApi.Data
{
    /// <summary>
    /// Represents a patient record.
    /// </summary>
    public record Patient
    {
        /// <summary>Gets or sets the unique user identifier for the patient.</summary>
        public int UserId { get; set; }
        /// <summary>Gets or sets the patient's NHS number.</summary>
        public int NHSNumber { get; set; }
        /// <summary>Gets or sets the full name of the patient.</summary>
        public string? Name { get; set; }
        /// <summary>Gets or sets the date of birth of the patient.</summary>
        public DateTime? DateOfBirth { get; set; }
        /// <summary>Gets or sets the name of the GP practice the patient is registered with.</summary>
        public string? GPPractice { get; set; }
    }
}
