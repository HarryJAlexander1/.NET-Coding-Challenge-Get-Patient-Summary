using System.Collections.Concurrent;

namespace PatientAccessApi.Data
{
    internal static class MockData
    {
        private static ConcurrentDictionary<int, Patient> Patients { get; } = new ConcurrentDictionary<int, Patient>
        {
            [1] = new Patient { UserId = 1, Name = "John Doe", DateOfBirth = new DateTime(1993, 4, 15), GPPractice = "GP Practice 1" },
            [2] = new Patient { UserId = 2, Name = "Jane Smith", DateOfBirth = new DateTime(1998, 7, 22), GPPractice = "GP Practice 2" },
            [3] = new Patient { UserId = 3, Name = "Alice Johnson", DateOfBirth = new DateTime(1985, 3, 10), GPPractice = "GP Practice 1" },
            [4] = new Patient { UserId = 4, Name = "Bob Williams", DateOfBirth = new DateTime(1972, 11, 5), GPPractice = "GP Practice 3" },
            [5] = new Patient { UserId = 5, Name = "Carol Brown", DateOfBirth = new DateTime(2001, 8, 19), GPPractice = "GP Practice 2" },
        };

        internal static Patient? GetPatientById(int userId)
        {
            Patients.TryGetValue(userId, out var patient);
            return patient;
        }
    }
}
