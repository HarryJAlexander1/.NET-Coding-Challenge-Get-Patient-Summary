using PatientAccessApi.Data;
using PatientAccessApi.Endpoints.Requests;
using PatientAccessApi.Log;

namespace PatientAccessApi
{
    internal class StorageHandler
    {
        private readonly LogHandler _logHandler;
        internal StorageHandler(LogHandler logHandler)
        {
            _logHandler = logHandler;
        }

        internal async Task<Patient?> GetPatientDetails(PatientDetailsRequest request)
        {
            try
            {
                var patient = MockData.GetPatientById(request.UserId);
                return patient;
            }
            catch (Exception ex)
            {
                _logHandler.WriteLog(new Log.Log(ex.Message, Log.LogLevel.Error));
                return null;
            }
        }
    }
}
