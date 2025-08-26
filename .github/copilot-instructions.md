# DemoAPI Project Instructions

DemoAPI is an ASP.NET Core Web API project targeting .NET 7.0. It provides a basic API template with Swagger/OpenAPI documentation support and includes model classes for Activity and Designee entities.

**ALWAYS reference these instructions first and fallback to search or bash commands only when you encounter unexpected information that does not match the info here.**

## Working Effectively

### Prerequisites and Setup
- Install .NET 7.0 Runtime (required for running the application):
  ```bash
  curl -sSL https://dot.net/v1/dotnet-install.sh | bash /dev/stdin --channel 7.0 --runtime aspnetcore
  export PATH="$HOME/.dotnet:$PATH"
  ```
- .NET SDK 8.0+ is compatible for building (targets .NET 7.0)
- Docker (optional, for containerized deployment)

### Build and Development Workflow
- **Bootstrap and build the project (NEVER CANCEL - Set timeout to 180+ seconds):**
  ```bash
  dotnet restore  # Takes ~8 seconds. NEVER CANCEL.
  dotnet build    # Takes ~6 seconds. NEVER CANCEL.
  ```

### Running the Application  
- **Development mode (with Swagger UI) - RECOMMENDED METHOD:**
  ```bash
  # Build first, then run compiled binary with .NET 7.0 runtime
  dotnet build
  export PATH="$HOME/.dotnet:$PATH"
  ASPNETCORE_ENVIRONMENT=Development dotnet bin/Debug/net7.0/DemoAPI.dll
  # Application starts on http://localhost:5000
  # Swagger UI available at http://localhost:5000/swagger/
  ```

- **Production mode (no Swagger UI):**
  ```bash
  # Build first, then run compiled binary
  dotnet build
  export PATH="$HOME/.dotnet:$PATH"
  dotnet bin/Debug/net7.0/DemoAPI.dll
  # Application starts on http://localhost:5000
  # Swagger UI is disabled in production
  ```

- **Alternative: Direct dotnet run (requires .NET 7.0 SDK):**
  ```bash
  # This requires .NET 7.0 SDK installation - may not work on all systems
  ASPNETCORE_ENVIRONMENT=Development dotnet run
  ```

### Testing
- **No unit tests are present in this project**
- Manual testing must be done through the API endpoints
- Use `dotnet test` to verify (will complete quickly with no tests found)

### Docker Deployment
- **Build Docker image (NEVER CANCEL - Set timeout to 600+ seconds):**
  ```bash
  docker build -t demoapi .
  # Takes ~6+ minutes. NEVER CANCEL.
  # May fail due to NuGet network issues - this is a known limitation
  ```

- **Run Docker container:**
  ```bash
  docker run -p 8080:8080 demoapi
  # Application available on http://localhost:8080
  ```

## Validation Scenarios

**ALWAYS manually validate any changes by running through these complete end-to-end scenarios:**

### Basic Application Validation
1. **Build validation:**
   ```bash
   dotnet clean && dotnet restore && dotnet build
   # Should complete without errors in ~14 seconds total
   ```

2. **Development environment validation:**
   ```bash
   dotnet build
   export PATH="$HOME/.dotnet:$PATH"
   ASPNETCORE_ENVIRONMENT=Development dotnet bin/Debug/net7.0/DemoAPI.dll &
   sleep 10
   curl -s -o /dev/null -w "%{http_code}" http://localhost:5000/swagger/
   # Should return 301 (redirect to Swagger UI)
   sudo pkill -f dotnet
   ```

3. **API functionality validation:**
   ```bash
   dotnet build
   export PATH="$HOME/.dotnet:$PATH"
   ASPNETCORE_ENVIRONMENT=Development dotnet bin/Debug/net7.0/DemoAPI.dll &
   sleep 10
   curl -s http://localhost:5000/swagger/v1/swagger.json | jq -r '.info.title'
   # Should return "DemoAPI"
   sudo pkill -f dotnet
   ```

### Manual Testing Checklist
After making any changes, ALWAYS verify:
- [ ] Application builds successfully (`dotnet build`)
- [ ] Application starts without errors (use compiled binary method)
- [ ] Swagger UI loads in development mode (visit http://localhost:5000/swagger/)
- [ ] Basic API structure is intact (check swagger.json endpoint)
- [ ] "No operations defined in spec!" message appears (expected for template project)

## Critical Timing and Timeout Information

**NEVER CANCEL the following operations. Always set appropriate timeouts:**

- `dotnet restore`: ~8 seconds - **Set timeout to 180 seconds minimum**
- `dotnet build`: ~6 seconds - **Set timeout to 180 seconds minimum**
- `dotnet run`: Starts in ~5 seconds - **Allow 60 seconds for startup**
- `docker build`: ~6+ minutes - **Set timeout to 600+ seconds minimum, may fail due to network**

## Project Structure and Key Files

### Repository Root Files
```
.
├── .dockerignore          # Docker ignore rules
├── .gitignore            # Git ignore rules  
├── Activity.cs           # Activity model class
├── DemoAPI.csproj        # Project file (.NET 7.0 target)
├── DemoAPI.sln           # Solution file
├── Designee.cs           # Designee model class  
├── Dockerfile            # Multi-stage Docker build
├── Program.cs            # Application entry point and configuration
├── WeatherForecast.cs    # Example model class (excluded from build)
├── appsettings.json      # Production configuration
└── appsettings.Development.json  # Development configuration
```

### Key Dependencies (from DemoAPI.csproj)
- `Microsoft.AspNetCore.OpenApi` (7.0.3) - OpenAPI support
- `Microsoft.VisualStudio.Azure.Containers.Tools.Targets` (1.17.0) - Container tools
- `Swashbuckle.AspNetCore` (6.4.0) - Swagger/OpenAPI UI

### Important Configuration Notes
- **Swagger UI only available in Development environment** - configured in Program.cs
- Default ports: 5000 (HTTP), 443 (HTTPS), 8080 (Docker)
- No controllers are currently implemented - this is a template project
- WeatherForecast controller is excluded from compilation (see .csproj)

## Common Tasks and Known Issues

### Environment-Specific Behavior
- **Development**: Swagger UI enabled, detailed error pages
- **Production**: Swagger UI disabled, minimal error disclosure

### Known Limitations
- Docker builds may fail due to NuGet network connectivity issues
- Project targets .NET 7.0 but most systems have .NET 8.0+ by default
- No actual API endpoints are implemented (template project)
- No authentication/authorization configured

### Quick Reference Commands
```bash
# Clean and rebuild
dotnet clean && dotnet restore && dotnet build

# Run in development with Swagger (RECOMMENDED)
dotnet build
export PATH="$HOME/.dotnet:$PATH"
ASPNETCORE_ENVIRONMENT=Development dotnet bin/Debug/net7.0/DemoAPI.dll

# Check application health (returns 404 - expected for template)
curl -s -o /dev/null -w "%{http_code}" http://localhost:5000/

# View Swagger spec
curl -s http://localhost:5000/swagger/v1/swagger.json | jq

# Build for production
dotnet publish -c Release

# Stop any running instances
sudo pkill -f dotnet
```

**Remember: ALWAYS build and test your changes before committing. This project has no automated tests, so manual validation is critical.**