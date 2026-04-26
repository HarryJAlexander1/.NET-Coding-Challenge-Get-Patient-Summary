# PatientAccessApi.Tests — Test Documentation

## Overview

`PatientAccessApi.Tests` is an xUnit integration test project targeting .NET 10. It uses `Microsoft.AspNetCore.Mvc.Testing` to spin up the full API in-process, sending real HTTP requests against the `/patient/get` endpoint without requiring a separately running server.

---

## Technology Stack

| Package | Purpose |
|---|---|
| `xunit` | Test framework. |
| `xunit.runner.visualstudio` | Integrates xUnit with Visual Studio Test Explorer. |
| `Microsoft.AspNetCore.Mvc.Testing` | Hosts the API in-process via `WebApplicationFactory`. |
| `Microsoft.NET.Test.Sdk` | Required MSBuild test runner infrastructure. |
| `Moq` | Mocking library, available for unit tests. |
| `coverlet.collector` | Code coverage data collection. |

---

## Project Structure

```
PatientAccessApi.Tests/
└── Endpoints/
    └── PatientEndpointsTests.cs   # Integration tests for /patient/get
```

---

## Running the Tests

### Visual Studio

Open **Test Explorer** (`Test → Test Explorer`) and click **Run All**.

### Command Line

```powershell
cd PatientAccessApi.Tests
dotnet test
```

## Test Coverage — `PatientEndpointsTests`

All tests target the `GET /patient/get` endpoint and are integration tests using a shared `WebApplicationFactory<Program>` fixture, meaning the full middleware pipeline runs for every request.

The API key used in tests matches the value set in `appsettings.json` (`"api-key"`).

| Test | Description | Expected Status |
|---|---|---|
| `GetPatient_ValidRequest_ReturnsOkWithPatient` | Valid API key and known `userId=1`. Asserts 200 and correct `UserId` on the returned patient. | `200 OK` |
| `GetPatient_MissingApiKey_ReturnsUnauthorized` | No `X-Api-Key` header supplied. | `401 Unauthorized` |
| `GetPatient_InvalidApiKey_ReturnsUnauthorized` | Incorrect value supplied in `X-Api-Key` header. | `401 Unauthorized` |
| `GetPatient_PatientNotFound_ReturnsNotFound` | Valid API key but `userId=9999` which does not exist in mock data. | `404 Not Found` |
| `GetPatient_AllMockPatients_ReturnCorrectName` | Theory test iterating all five mock patients. Asserts 200 and correct `Name` for each. | `200 OK` |

---

## Mock Data

The API serves the following in-memory patients when `GenerateMockData` is `true`:

| UserId | Name | Date of Birth | GP Practice |
|---|---|---|---|
| 1 | John Doe | 15/04/1993 | GP Practice 1 |
| 2 | Jane Smith | 22/07/1998 | GP Practice 2 |
| 3 | Alice Johnson | 10/03/1985 | GP Practice 1 |
| 4 | Bob Williams | 05/11/1972 | GP Practice 3 |
| 5 | Carol Brown | 19/08/2001 | GP Practice 2 |

---