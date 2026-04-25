using PatientAccessApi.Endpoints.Requests;
using Microsoft.AspNetCore.Mvc;
using PatientAccessApi.Endpoints.Responses;
using PatientAccessApi.Services;
using PatientAccessApi.Log;
using Microsoft.Extensions.Options;

namespace PatientAccessApi.Endpoints
{
    /// <summary>
    /// Defines and maps the patient-related API endpoints.
    /// </summary>
    public class PatientAccessEndpoints
    {
        private readonly Server _server;
        private readonly LogHandler _logHandler;
        private readonly Config _config;
        /// <summary>
        /// Initialises a new instance of <see cref="PatientAccessEndpoints"/>.
        /// </summary>
        /// <param name="server">The server service used to handle patient requests.</param>
        /// <param name="logHandler">The log handler used to record endpoint events.</param>
        /// <param name="config">The application configuration options.</param>
        public PatientAccessEndpoints(Server server, LogHandler logHandler, IOptions<Config> config)
        {
            _server = server;
            _logHandler = logHandler;
            _config = config.Value;
        }

        /// <summary>
        /// Maps all patient endpoints onto the provided <see cref="WebApplication"/>.
        /// </summary>
        /// <param name="app">The web application to map the endpoints onto.</param>
        internal void MapPatientEndpoints(ref WebApplication app)
        {
            var group = app.MapGroup("/patient");

            group.MapGet("/get", async (HttpContext httpContext, int userId) =>
            {
                if (!httpContext.Request.Headers.TryGetValue("X-Api-Key", out var apiKey) || apiKey != _config.ApiKey)
                {
                    return Results.Unauthorized();
                }

                var request = new PatientDetailsRequest { UserId = userId };
                var result = await _server.GetPatient(request);
                return result;
            })
            .Accepts<PatientDetailsRequest>("application/json")
            .Produces<PatientDetailsResponse>(StatusCodes.Status200OK, "application/json")
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .WithDisplayName("get")
            .WithTags("get");

            _logHandler.WriteLog(new Log.Log("Mapped /patient/get endpoint", Log.LogLevel.Info));
        }
    }
}
