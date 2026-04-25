using PatientAccessApi.Endpoints.Requests;
using Microsoft.AspNetCore.Mvc;
using PatientAccessApi.Endpoints.Responses;
using PatientAccessApi.Services;
using PatientAccessApi.Log;

namespace PatientAccessApi.Endpoints
{
    internal class PatientAccessEndpoints
    {
        private readonly Server _server;
        private readonly LogHandler _logHandler;
        internal PatientAccessEndpoints(Server server, LogHandler logHandler)
        {
            _server = server;
            _logHandler = logHandler;
        }

        internal void MapPatientEndpoints(ref WebApplication app)
        {
            var group = app.MapGroup("/patient");

            group.MapGet("/get", async ([FromBody] PatientDetailsRequest request) =>
            {
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
