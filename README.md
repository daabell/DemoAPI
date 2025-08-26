# DemoAPI

A simple ASP.NET Core Web API targeting .NET 9.

## Prerequisites

- .NET 9 SDK
- Docker (for containerization)

## Building and Running

### Local Development

To build and run locally, you'll need the .NET 9 SDK installed:

```bash
dotnet build
dotnet run
```

### Docker

The application is configured to run in Docker containers using .NET 9 images:

```bash
docker build -t demoapi .
docker run -p 8080:8080 demoapi
```

## API Features

- Weather forecast endpoints
- Activity and Designee management
- Swagger/OpenAPI documentation
- ASP.NET Core minimal APIs

## .NET 9

This project has been configured to target .NET 9 to take advantage of the latest features and performance improvements. The configuration includes:

- Target framework: `net9.0`
- Updated package references compatible with .NET 9
- Docker images using .NET 9 runtime and SDK
- Global.json configuration for SDK version management

Note: .NET 9 SDK is required to build and run this application locally.