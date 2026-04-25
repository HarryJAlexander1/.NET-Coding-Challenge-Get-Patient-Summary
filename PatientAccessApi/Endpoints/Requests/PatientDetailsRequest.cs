namespace PatientAccessApi.Endpoints.Requests
{
    [Serializable]
    internal record PatientDetailsRequest : IRequest
    {
        public int UserId { get; set; }
    }
}
