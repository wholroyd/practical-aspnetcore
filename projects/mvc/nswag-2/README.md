# Built-in OpenAPI with MVC Controllers

This sample demonstrates ASP.NET Core 10's built-in OpenAPI support with MVC controllers and tags.

## Key Features

- No external packages required (NSwag removed)
- OpenAPI 3.1 document generated automatically
- XML doc comments populate API descriptions
- Modern Scalar UI for interactive documentation
- Demonstrates tag grouping with `[Tags("Category")]` attribute
- Shows endpoint exclusion with `[ApiExplorerSettings(IgnoreApi = true)]`
- AOT-compatible

## Running the Sample

```bash
dotnet watch run
```

Navigate to `http://localhost:5000/` to see the home page.

## Viewing the Documentation

- **Scalar UI:** Navigate to `/scalar`
- **OpenAPI JSON:** Navigate to `/openapi/v1.json`

## Endpoints

### Basic
- `GET /api/greeting` - Returns "Hello World" message
- `POST /api/greeting/goodbye` - Returns goodbye message with name

### Intermediate
- `PUT /api/greeting` - Relays a greeting
- `DELETE /api/greeting/greetings/{name}` - Removes a greeting

### Advanced
- `PATCH /api/greeting` - Updates greeting with city

## Migration Notes

This sample was migrated from NSwag to .NET 10's built-in OpenAPI support.

**Changes:**
- Removed `NSwag.AspNetCore` and `NSwag.Annotations` package dependencies
- Added `Microsoft.AspNetCore.OpenApi` (built-in)
- Added `Scalar.AspNetCore` for modern UI
- Replaced `[OpenApiTag("Basic")]` with `[Tags("Basic")]`
- Replaced `[OpenApiIgnore]` with `[ApiExplorerSettings(IgnoreApi = true)]`
- Enabled `GenerateDocumentationFile` in .csproj

**Benefits:**
- Uses built-in .NET 10 OpenAPI support
- Cleaner tag management
- Modern Scalar UI instead of Swagger UI
- Better AOT compatibility

See `OUT-OF-DATE.md` for migration details.
