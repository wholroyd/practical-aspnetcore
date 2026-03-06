# Built-in OpenAPI with Scalar UI

This sample demonstrates ASP.NET Core 10's built-in OpenAPI 3.1 support.

## Key Features

- No external packages required (Swashbuckle/NSwag removed)
- OpenAPI 3.1 document generated automatically
- XML doc comments populate API descriptions
- Modern Scalar UI for interactive documentation
- AOT-compatible

## Running the Sample

```bash
dotnet watch run
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
- Replaced `WithOpenApi()` with XML documentation comments
- Enabled `GenerateDocumentationFile` in .csproj

See `OUT-OF-DATE.md` for migration details.
