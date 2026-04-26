# .NET Coding Challenge — Patient Access API

A minimal .NET 10 Web API for retrieving patient summary information, with an accompanying xUnit integration test project.

---

## Solution Structure

```
dotnet-coding-challenge/
├── PatientAccessApi/                  # The Web API project
│   ├── Data/                          # Patient model and mock data store
│   ├── Documentation/                 # Detailed documentation (see below)
│   │   ├── API.md                     # API endpoint and configuration reference
│   │   └── Tests.md                   # Test project reference
│   ├── Endpoints/                     # Minimal API endpoint definitions and request/response models
│   ├── Extensions/                    # IServiceCollection registration extensions
│   ├── Log/                           # Logging infrastructure
│   ├── Services/                      # Core business logic (Server)
│   ├── appsettings.json               # Application configuration
│   └── Program.cs                     # Application entry point
└── PatientAccessApi.Tests/            # xUnit integration test project
    └── Endpoints/
        └── PatientEndpointsTests.cs   # Integration tests for /patient/get
```

---

## Documentation

| Document | Description |
|---|---|
| [`PatientAccessApi/Documentation/API.md`](PatientAccessApi/Documentation/API.md) | Configuration, authentication, endpoint reference, and examples. |
| [`PatientAccessApi/Documentation/Tests.md`](PatientAccessApi/Documentation/Tests.md) | Test project setup, test descriptions, and guidance for adding new tests. |

---

## Quick Start

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)

### Run the API

```powershell
cd PatientAccessApi
dotnet run
```

### Run the Tests

```powershell
cd PatientAccessApi.Tests
dotnet test
```

---

## Authentication

All API requests require an `X-Api-Key` header. The expected key value is configured in `PatientAccessApi/appsettings.json` under `PatientAccessAPI.ApiKey`.
