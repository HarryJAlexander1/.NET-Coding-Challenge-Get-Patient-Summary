# PatientAccessApi — API Documentation

## Overview

PatientAccessApi is a minimal .NET 10 Web API for retrieving patient summary information. All endpoints are grouped under the `/patient` route prefix and require a valid API key to be supplied in the request header.

---

## Configuration

Settings are bound from the `PatientAccessAPI` section of `appsettings.json`:

| Key | Type | Description |
|---|---|---|
| `ApiKey` | `string` | The secret key that must be supplied in the `X-Api-Key` request header. |
| `GenerateMockData` | `bool` | When `true`, the application serves mock patient records. |
| `EnableLogs` | `bool` | When `true`, log entries are written to disk. |
| `LogDirectory` | `string` | Directory path where log files are written (default: `.\systemlogs`). |

**Example `appsettings.json`:**

```json
{
  "PatientAccessAPI": {
    "ApiKey": "your-secret-key",
    "GenerateMockData": true,
    "EnableLogs": true,
    "LogDirectory": ".\\systemlogs"
  }
}
```

---

## Authentication

Every request must include the API key in the `X-Api-Key` HTTP header.

| Condition | Response |
|---|---|
| Header present and key matches configuration | Request is processed normally. |
| Header missing or key does not match | `401 Unauthorized` |

---

## Endpoints

### GET `/patient/get`

Retrieves the details of a single patient by their user ID.

#### Query Parameters

| Parameter | Type | Required | Description |
|---|---|---|---|
| `userId` | `int` | Yes | The unique identifier of the patient to retrieve. |

#### Request Headers

| Header | Required | Description |
|---|---|---|
| `X-Api-Key` | Yes | The API key configured in `appsettings.json`. |

#### Responses

| Status Code | Description |
|---|---|
| `200 OK` | Patient found. Body contains the `Patient` JSON object. |
| `401 Unauthorized` | API key is missing or invalid. |
| `404 Not Found` | No patient exists for the provided `userId`. |
| `500 Internal Server Error` | An unexpected error occurred. |

#### Example Request

```http
GET /patient/get?userId=1
X-Api-Key: your-secret-key
```

#### Example Response — 200 OK

```json
{
  "userId": 1,
  "nhsNumber": 0,
  "name": "John Doe",
  "dateOfBirth": "1993-04-15T00:00:00",
  "gpPractice": "GP Practice 1"
}
```

#### Example Response — 404 Not Found

```
Patient details not found for userId 9999.
```

---

## Running the API

```powershell
cd PatientAccessApi
dotnet run
```

By default the API is available at `https://localhost:{port}`. The OpenAPI document is served at `/openapi/v1.json` in the Development environment.

---

## Logging

When `EnableLogs` is `true`, a file named `application.log` is created in the directory specified by `LogDirectory`. Each entry follows the format:

```
yyyy-MM-dd HH:mm:ss [Level] "Message" (Caller: MethodName)
```
