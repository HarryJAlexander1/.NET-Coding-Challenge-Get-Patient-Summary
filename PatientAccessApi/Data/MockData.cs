using Microsoft.Extensions.Options;
using PatientAccessApi.Log;
using System.Collections.Concurrent;

namespace PatientAccessApi.Data
{
    /// <summary>
    /// Provides static in-memory mock patient data for development and testing purposes.
    /// </summary>
    public class MockData
    {
        private readonly LogHandler _logHandler;
        private readonly ConcurrentDictionary<int, Patient> _patients;

        public MockData(LogHandler logHandler, IOptions<Config> config)
        {
            _logHandler = logHandler;

            if (config.Value.GenerateMockData != null && config.Value.GenerateMockData.Value)
            {
                _patients = new ConcurrentDictionary<int, Patient>()
                {
                    [1] = new Patient { UserId = 1, Name = "John Doe", DateOfBirth = new DateTime(1993, 4, 15), GPPractice = "GP Practice 1" },
                    [2] = new Patient { UserId = 2, Name = "Jane Smith", DateOfBirth = new DateTime(1998, 7, 22), GPPractice = "GP Practice 2" },
                    [3] = new Patient { UserId = 3, Name = "Alice Johnson", DateOfBirth = new DateTime(1985, 3, 10), GPPractice = "GP Practice 1" },
                    [4] = new Patient { UserId = 4, Name = "Bob Williams", DateOfBirth = new DateTime(1972, 11, 5), GPPractice = "GP Practice 3" },
                    [5] = new Patient { UserId = 5, Name = "Carol Brown", DateOfBirth = new DateTime(2001, 8, 19), GPPractice = "GP Practice 2" },
                };
                _logHandler.WriteLog(new Log.Log("Mock patient data generated successfully.", Log.LogLevel.Info));
                return;
            }

            _patients = new ConcurrentDictionary<int, Patient>();
            _logHandler.WriteLog(new Log.Log("Mock patient data generation is disabled in configuration.", Log.LogLevel.Info));
        }

        /// <summary>
        /// Retrieves a patient from the mock data store by their user ID.
        /// </summary>
        /// <param name="userId">The unique identifier of the patient to retrieve.</param>
        /// <returns>The matching <see cref="Patient"/>, or <c>null</c> if not found.</returns>
        internal Patient? GetPatientById(int userId)
        {
            _patients.TryGetValue(userId, out var patient);
            return patient;
        }
    }
}
