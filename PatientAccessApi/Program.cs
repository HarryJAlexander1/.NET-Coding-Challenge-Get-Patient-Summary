using PatientAccessApi.Endpoints;
using PatientAccessApi.Extensions;

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddOpenApi();
    builder.Services.RegisterServices(builder.Configuration);

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
    }

    var patientAccessEndpoints = app.Services.GetRequiredService<PatientAccessEndpoints>();
    patientAccessEndpoints.MapPatientEndpoints(ref app);

    app.UseHttpsRedirection();

    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine($"Error: An unexpected error occurred while starting the application. Exception: {ex.Message}");
}
