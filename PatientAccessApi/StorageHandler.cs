using PatientAccessApi.Data;
using PatientAccessApi.Endpoints.Requests;
using PatientAccessApi.Log;

namespace PatientAccessApi
{
    /// <summary>
    /// Handles data retrieval operations, acting as the layer between the service and the data store.
    /// </summary>
    public class StorageHandler
    {
        private readonly LogHandler _logHandler;
        private readonly MockData _mockData;

        /// <summary>
        /// Initialises a new instance of <see cref="StorageHandler"/>.
        /// </summary>
        /// <param name="logHandler">The log handler used to record storage events.</param>
        /// <param name="mockData">The mock data store used for retrieving patient information.</param>
        public StorageHandler(LogHandler logHandler, MockData mockData)
        {
            _logHandler = logHandler;
            _mockData = mockData;
        }

        /// <summary>
        /// Retrieves patient details from the data store for the given request.
        /// </summary>
        /// <param name="request">The request containing the user ID to look up.</param>
        /// <returns>The matching <see cref="Patient"/>, or <c>null</c> if not found or an error occurs.</returns>
        internal async Task<Patient?> GetPatientDetails(PatientDetailsRequest request)
        {
            try
            {
                var patient = _mockData.GetPatientById(request.UserId);
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
