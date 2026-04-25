namespace PatientAccessApi.Endpoints.Responses
{
    public interface IResponse
    {
        int UserId { get; set; }
        public int NHSNumber { get; set; }
    }
}
