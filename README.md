# DemoAPI

A simple ASP.NET Core Web API targeting .NET 10 preview.

## Prerequisites

- .NET 10 preview SDK (when available)
- Docker (for containerization)

## Building and Running

### Local Development

To build and run locally, you'll need the .NET 10 preview SDK installed:

```bash
dotnet build
dotnet run
```

### Docker

The application is configured to run in Docker containers using .NET 10 preview images:

```bash
docker build -t demoapi .
docker run -p 8080:8080 demoapi
```

## API Features

- Weather forecast endpoints
- Activity and Designee management
- Swagger/OpenAPI documentation
- ASP.NET Core minimal APIs

## .NET 10 Preview

This project has been configured to target .NET 10 preview to take advantage of the latest features and performance improvements. The configuration includes:

- Target framework: `net10.0`
- Updated package references compatible with .NET 10
- Docker images using .NET 10 preview runtime and SDK
- Global.json configuration for SDK version management

Note: .NET 10 preview SDK is required to build and run this application locally.