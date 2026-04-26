using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;
using PatientAccessApi.Data;
using Xunit;

namespace PatientAccessApi.Tests.Endpoints
{
    /// <summary>
    /// Integration tests for the <c>/patient/get</c> endpoint.
    /// </summary>
    public class PatientEndpointsTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private const string ValidApiKey = "api-key";
        private const string ApiKeyHeader = "X-Api-Key";
        private const string Endpoint = "/patient/get";

        private readonly HttpClient _client;

        public PatientEndpointsTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetPatient_ValidRequest_ReturnsOkWithPatient()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{Endpoint}?userId=1");
            request.Headers.Add(ApiKeyHeader, ValidApiKey);

            var response = await _client.SendAsync(request);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var patient = await response.Content.ReadFromJsonAsync<Patient>();
            Assert.NotNull(patient);
            Assert.Equal(1, patient.UserId);
        }

        [Fact]
        public async Task GetPatient_MissingApiKey_ReturnsUnauthorized()
        {
            var response = await _client.GetAsync($"{Endpoint}?userId=1");

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task GetPatient_InvalidApiKey_ReturnsUnauthorized()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{Endpoint}?userId=1");
            request.Headers.Add(ApiKeyHeader, "wrong-key");

            var response = await _client.SendAsync(request);

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task GetPatient_PatientNotFound_ReturnsNotFound()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{Endpoint}?userId=9999");
            request.Headers.Add(ApiKeyHeader, ValidApiKey);

            var response = await _client.SendAsync(request);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Theory]
        [InlineData(1, "John Doe")]
        [InlineData(2, "Jane Smith")]
        [InlineData(3, "Alice Johnson")]
        [InlineData(4, "Bob Williams")]
        [InlineData(5, "Carol Brown")]
        public async Task GetPatient_AllMockPatients_ReturnCorrectName(int userId, string expectedName)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{Endpoint}?userId={userId}");
            request.Headers.Add(ApiKeyHeader, ValidApiKey);

            var response = await _client.SendAsync(request);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var patient = await response.Content.ReadFromJsonAsync<Patient>();
            Assert.NotNull(patient);
            Assert.Equal(expectedName, patient.Name);
        }
    }
}
