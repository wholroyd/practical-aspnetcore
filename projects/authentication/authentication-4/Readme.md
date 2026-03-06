# Built-in OpenAPI with JWT Bearer Authentication

This sample demonstrates ASP.NET Core 10's built-in OpenAPI 3.1 support with JWT Bearer authentication and MVC controllers.

## Key Features

- JWT Bearer authentication with minimal configuration
- Built-in OpenAPI 3.1 support (no Swashbuckle/NSwag required)
- Modern Scalar UI for interactive API documentation
- MVC controllers pattern

## Running the Sample

```bash
dotnet watch run
```

## Generating a JWT Token

To generate a bearer token, run:

```bash
dotnet user-jwts create
```

## Viewing the Documentation

- **Scalar UI:** Navigate to `/scalar`
- **OpenAPI JSON:** Navigate to `/openapi/v1.json`

## Migration Notes

This sample was migrated from Swashbuckle to .NET 10's built-in OpenAPI support.

**Changes:**
- Removed `Swashbuckle.AspNetCore` package dependency
- Added `Microsoft.AspNetCore.OpenApi` (built-in)
- Added `Scalar.AspNetCore` for modern UI
- Enabled `GenerateDocumentationFile` in .csproj
- Updated JWT Bearer package to .NET 10 preview

See `OUT-OF-DATE.md` for migration details.
