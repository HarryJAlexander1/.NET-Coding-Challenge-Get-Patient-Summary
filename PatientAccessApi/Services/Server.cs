using Microsoft.AspNetCore.Identity.Data;
using PatientAccessApi.Endpoints.Requests;
using PatientAccessApi.Log;

namespace PatientAccessApi.Services
{
    public class Server
    {
        private readonly LogHandler _logHandler;
        private readonly StorageHandler _storageHandler;
        public Server(StorageHandler storageHandler, LogHandler logHandler)
        {
            _storageHandler = storageHandler;
            _logHandler = logHandler;
        }

        internal async Task<IResult> GetPatient(PatientDetailsRequest request)
        {
            try
            {
                var patient = await _storageHandler.GetPatientDetails(request);

                if (patient is null)
                {
                    var errorMessage = $"Patient details not found for userId {request.UserId}.";
                    _logHandler.WriteLog(new Log.Log(errorMessage, Log.LogLevel.Error));
                    return TypedResults.NotFound(errorMessage);
                }

                _logHandler.WriteLog(new Log.Log($"Successfully retrieved patient details for userId {request.UserId}.", Log.LogLevel.Info));
                return TypedResults.Ok(patient);
            }
            catch (Exception ex)
            {
                var message = $"Error: An unexpected error occurred while retrieving patient details for userId {request.UserId}. Exception: {ex.Message}";
                _logHandler.WriteLog(new Log.Log(message, Log.LogLevel.Error));
                return TypedResults.Problem(message);
            }
        }
    }
}
