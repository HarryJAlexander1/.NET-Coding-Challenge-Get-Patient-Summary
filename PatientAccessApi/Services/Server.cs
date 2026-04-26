using Microsoft.AspNetCore.Identity.Data;
using PatientAccessApi.Data;
using PatientAccessApi.Endpoints.Requests;
using PatientAccessApi.Log;
using System.Diagnostics;

namespace PatientAccessApi.Services
{
    /// <summary>
    /// Provides the core business logic for handling patient data requests.
    /// </summary>
    public class Server
    {
        private readonly LogHandler _logHandler;
        private readonly StorageHandler _storageHandler;
        /// <summary>
        /// Initialises a new instance of <see cref="Server"/>.
        /// </summary>
        /// <param name="storageHandler">The storage handler used to retrieve patient data.</param>
        /// <param name="logHandler">The log handler used to record service events.</param>
        public Server(StorageHandler storageHandler, LogHandler logHandler)
        {
            _storageHandler = storageHandler;
            _logHandler = logHandler;
        }

        /// <summary>
        /// Retrieves patient details for the specified request.
        /// </summary>
        /// <param name="request">The request containing the user ID of the patient to retrieve.</param>
        /// <returns>
        /// A <see cref="Patient?"/> representing the patient on success, or null if the patient does not exist.
        /// </returns>
        internal async Task<Patient?> GetPatient(PatientDetailsRequest request)
        {
            var stopwatch = Stopwatch.StartNew();

            var patient = await _storageHandler.GetPatientDetails(request);

            stopwatch.Stop();

            if (stopwatch.ElapsedMilliseconds > 1000) // Log a warning if retrieval took longer than 1 second
            {
                _logHandler.WriteLog(new Log.Log($"Retrieving patient details for userId {request.UserId} took {stopwatch.ElapsedMilliseconds} ms.", Log.LogLevel.Warning));
            }

            if (patient is null)
            {
                var errorMessage = $"Patient details not found for userId {request.UserId}.";
                _logHandler.WriteLog(new Log.Log(errorMessage, Log.LogLevel.Error));
                return null;
            }

            _logHandler.WriteLog(new Log.Log($"Successfully retrieved patient details for userId {request.UserId}.", Log.LogLevel.Info));

            return patient;
        }
    }
}
