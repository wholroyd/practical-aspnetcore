# .NET 10 Migration Plan

**Generated:** 2026-03-06  
**Status:** Ready for Execution  
**Estimated Time:** 3.5 hours  
**Total Commits:** 13 (12 samples + 1 documentation)

---

## Overview

This plan addresses **13 outdated samples** identified in `OUT-OF-DATE.md`, migrating them to use modern .NET 10 APIs. 

### Migration Strategy
- **Approach:** Update in-place (replace old code with modern patterns)
- **OpenAPI UI:** Scalar UI (modern, clean, AOT-compatible)
- **Scope:** HIGH + MEDIUM priority items
- **Git:** One atomic commit per sample migration

### What's Being Migrated

| Priority | Category | Samples | Effort |
|----------|----------|---------|--------|
| HIGH | Swashbuckle → Built-in OpenAPI | 10 | 2 hours |
| HIGH | Manual SSE → Built-in SSE | 1 | 15 min |
| MEDIUM | NSwag → Built-in OpenAPI (MVC) | 1 | 15 min |
| MEDIUM | Custom IHostedService → BackgroundService | 1 | 15 min |
| FINAL | Documentation updates | 1 | 30 min |

---

## For Next Agent Session

### Before You Start

1. **Read this file completely** before executing any migrations
2. **Check git status:** `git status` should show clean working directory
3. **Choose branch strategy:**
   ```bash
   # Option 1: Work on main (if you have push access)
   git checkout main
   git pull origin main
   
   # Option 2: Create feature branch (recommended)
   git checkout -b migrate-to-net10-patterns
   ```

### Execution Order

Follow this order for best results:

1. **Phase 1: OpenAPI Samples (10 samples, ~2 hours)**
   - Start with `open-api-1` (establishes pattern)
   - Continue with `open-api-2`, then `map-group-*`, `map-4`
   - Then `pokedex`, `authentication-*` samples
   - Finally `nswag` and `nswag-2`

2. **Phase 2: SSE Sample (1 sample, ~15 min)**
   - Migrate `sse` to use `Results.ServerSentEvents()`

3. **Phase 3: IHostedService Sample (1 sample, ~15 min)**
   - Simplify `ihosted-service-1` to use `BackgroundService`

4. **Phase 4: Documentation (1 commit, ~30 min)**
   - Update all README files
   - Mark OUT-OF-DATE.md as completed

### For Each Sample Migration

**Follow this workflow:**

```bash
# 1. Navigate to sample
cd projects/<category>/<sample-name>

# 2. Read current implementation
cat Program.cs
cat <sample-name>.csproj
cat README.md

# 3. Make changes (see Migration Patterns below)
# - Update .csproj
# - Update Program.cs
# - Update README.md

# 4. Test thoroughly
dotnet build
dotnet watch run
# Test in browser (see Testing Checklist)

# 5. Stop the app (Ctrl+C)

# 6. Return to root
cd /mnt/d/GitHub/practical-aspnetcore

# 7. Review changes
git status
git diff projects/<category>/<sample-name>/

# 8. Stage changes
git add projects/<category>/<sample-name>/

# 9. Commit with message (see Commit Messages below)
git commit -m "..."

# 10. Verify commit
git log -1 --stat

# 11. Repeat for next sample
```

---

## Migration Patterns

### Pattern A: OpenAPI Migration (Swashbuckle → Built-in)

**Applies to:** `open-api-1`, `open-api-2`, `map-group-2`, `map-group-3`, `map-4`, `pokedex`, `authentication-4`, `authentication-5`, `nswag`, `nswag-2`

#### Step 1: Update .csproj File

**Location:** `projects/<category>/<sample-name>/<sample-name>.csproj`

**Remove:**
```xml
<PackageReference Include="Swashbuckle.AspNetCore" Version="..." />
<PackageReference Include="Microsoft.AspNetCore.OpenApi" Version="8.0.x" />
<PackageReference Include="NSwag.AspNetCore" Version="..." />
```

**Add:**
```xml
<PropertyGroup>
  <TargetFramework>net10.0</TargetFramework>
  <ImplicitUsings>true</ImplicitUsings>
  <GenerateDocumentationFile>true</GenerateDocumentationFile>
  <NoWarn>$(NoWarn);1591</NoWarn>
</PropertyGroup>

<ItemGroup>
  <PackageReference Include="Microsoft.AspNetCore.OpenApi" Version="10.0.0-preview.5.*" />
  <PackageReference Include="Scalar.AspNetCore" Version="2.1.13" />
</ItemGroup>
```

#### Step 2: Update Program.cs

**Location:** `projects/<category>/<sample-name>/Program.cs`

**Add at top:**
```csharp
using Scalar.AspNetCore;
```

**Remove:**
```csharp
// These using statements
using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi.Models;

// Service registration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setup => setup.SwaggerDoc("v1", new OpenApiInfo() { ... }));

// Middleware
app.UseSwagger();
app.UseSwaggerUI();

// For NSwag samples
builder.Services.AddSwaggerDocument(settings => { ... });
app.UseOpenApi();
app.UseSwaggerUi(settings => { ... });

// Extension method on endpoints
.WithOpenApi(op =>
{
    op.OperationId = "...";
    op.Summary = "...";
    return op;
});
```

**Add:**
```csharp
// Service registration (after other services)
builder.Services.AddOpenApi();

// Middleware (after app.Build(), before endpoints)
app.MapOpenApi();
app.MapScalarApiReference();
```

**Replace `.WithOpenApi()` with XML comments:**
```csharp
// BEFORE
app.MapGet("/greeting", Hello.GetGreeting).WithOpenApi(op =>
{
    op.OperationId = "GetGreetings";
    op.Summary = "Return greeting given name";
    return op;
});

// AFTER
/// <summary>
/// Return greeting given name
/// </summary>
/// <param name="name">The name of the person to greet</param>
app.MapGet("/greeting", Hello.GetGreeting);
```

**For MVC controllers (NSwag samples):**
```csharp
// Add XML comments to controller actions:
/// <summary>
/// Returns a hello world message
/// </summary>
/// <response code="200">The greeting message</response>
[HttpGet("")]
public ActionResult<Greeting> Index()
{
    return new Greeting { Message = "Hello World" };
}
```

#### Step 3: Update README.md

**Location:** `projects/<category>/<sample-name>/README.md`

**Replace content with:**
```markdown
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
```

**For NSwag samples, adjust to mention NSwag:**
```markdown
# Built-in OpenAPI with MVC Controllers

This sample demonstrates ASP.NET Core 10's built-in OpenAPI support with MVC controllers.

## Migration Notes

This sample was migrated from NSwag to .NET 10's built-in OpenAPI support.
```

---

### Pattern B: SSE Migration (Manual → Built-in)

**Applies to:** `sse`

#### Step 1: Update Program.cs

**Location:** `projects/sse/Program.cs`

**Add at top:**
```csharp
using System.Runtime.CompilerServices;
```

**Replace the entire `/sse` endpoint (lines 6-38) with:**
```csharp
app.MapGet("/sse", (HttpContext context, CancellationToken cancellationToken) =>
{
    async IAsyncEnumerable<string> CounterAsync([EnumeratorCancellation] CancellationToken ct)
    {
        int count = 0;
        while (!ct.IsCancellationRequested)
        {
            yield return $"hello world {++count}";
            await Task.Delay(3000, ct);
        }
    }

    if (context.Request.Headers.Accept == "text/event-stream")
    {
        return Results.ServerSentEvents(CounterAsync(cancellationToken), eventType: "message");
    }
    else
    {
        return Results.BadRequest("Unsupported Accept header. Use 'text/event-stream'.");
    }
});
```

**Remove the `Counter()` method at the bottom (lines 69-76) - no longer needed**

#### Step 2: Update README.md

**Location:** `projects/sse/README.md`

**Replace content with:**
```markdown
# Built-in Server-Sent Events

This sample demonstrates ASP.NET Core 10's built-in Server-Sent Events (SSE) support using `Results.ServerSentEvents()`.

## Running the Sample

```bash
dotnet watch run
```

Navigate to `http://localhost:5000/` to see the SSE client in action.

## Key Features

- Built-in SSE support via `Results.ServerSentEvents()`
- Type-safe with `IAsyncEnumerable<T>`
- Automatic flush management
- Proper cancellation token handling
- No manual protocol implementation needed

## How It Works

The endpoint returns `Results.ServerSentEvents()` with an `IAsyncEnumerable<string>`:

```csharp
app.MapGet("/sse", (HttpContext context, CancellationToken cancellationToken) =>
{
    async IAsyncEnumerable<string> CounterAsync([EnumeratorCancellation] CancellationToken ct)
    {
        int count = 0;
        while (!ct.IsCancellationRequested)
        {
            yield return $"hello world {++count}";
            await Task.Delay(3000, ct);
        }
    }

    if (context.Request.Headers.Accept == "text/event-stream")
    {
        return Results.ServerSentEvents(CounterAsync(cancellationToken), eventType: "message");
    }
    
    return Results.BadRequest("Use Accept: text/event-stream");
});
```

## Migration Notes

This sample was migrated from manual SSE implementation to .NET 10's built-in support.

**Changes:**
- Removed manual SSE protocol implementation (data/id/event formatting)
- Removed manual `Response.WriteAsync()` and `FlushAsync()` calls
- Added `Results.ServerSentEvents()` with `IAsyncEnumerable<string>`
- Added proper cancellation token handling with `[EnumeratorCancellation]`

See `OUT-OF-DATE.md` for migration details.

## Related Samples

- `projects/net10/sse-2/` - Basic SSE
- `projects/net10/sse-3/` - SSE with event types
- `projects/net10/sse-4/` - SSE with mixed events using `SseItem<T>`
```

---

### Pattern C: IHostedService Migration (Custom → BackgroundService)

**Applies to:** `ihosted-service-1`

#### Step 1: Update Program.cs

**Location:** `projects/ihosted-service/ihosted-service-1/Program.cs`

**Add at top:**
```csharp
using Microsoft.Extensions.Hosting;
```

**Remove the entire `HostedService` abstract class (lines 15-51)**

**Replace the `GreeterUpdaterService` class (lines 53-69) with:**
```csharp
public class GreeterUpdaterService : BackgroundService
{
    private readonly Greeter _greeter;
    
    public GreeterUpdaterService(Greeter greeter)
    {
        _greeter = greeter;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _greeter.Counter++;
            await Task.Delay(TimeSpan.FromSeconds(1), stoppingToken);
        }
    }
}
```

**Update the service registration (line 3):**
```csharp
// BEFORE
builder.Services.AddSingleton<Microsoft.Extensions.Hosting.IHostedService, GreeterUpdaterService>();

// AFTER
builder.Services.AddHostedService<GreeterUpdaterService>();
```

#### Step 2: Update README.md

**Location:** `projects/ihosted-service/ihosted-service-1/README.md`

**Replace content with:**
```markdown
# BackgroundService Pattern

This sample demonstrates using the `BackgroundService` base class for background tasks in ASP.NET Core.

## Running the Sample

```bash
dotnet watch run
```

Navigate to `http://localhost:5000/` and reload the page to see the counter incrementing.

## How It Works

A `GreeterUpdaterService` inherits from `BackgroundService` and updates a `Greeter` singleton every second:

```csharp
public class GreeterUpdaterService : BackgroundService
{
    private readonly Greeter _greeter;
    
    public GreeterUpdaterService(Greeter greeter)
    {
        _greeter = greeter;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _greeter.Counter++;
            await Task.Delay(TimeSpan.FromSeconds(1), stoppingToken);
        }
    }
}
```

## Registration

```csharp
builder.Services.AddSingleton<Greeter>();
builder.Services.AddHostedService<GreeterUpdaterService>();
```

## Migration Notes

This sample was simplified from a custom `IHostedService` implementation to using the built-in `BackgroundService` base class.

**Changes:**
- Removed custom `HostedService` abstract base class (40+ lines of boilerplate)
- Inherited from `Microsoft.Extensions.Hosting.BackgroundService`
- Simplified cancellation token handling
- Cleaner, more maintainable code

**Benefits:**
- Much less code to maintain
- `BackgroundService` handles all the boilerplate
- Built into `Microsoft.Extensions.Hosting`
- Standard pattern recommended by Microsoft

See `OUT-OF-DATE.md` for migration details.
```

---

## Testing Checklist

### For OpenAPI Samples

**Before each commit, verify:**

```bash
# 1. Build succeeds
cd projects/<category>/<sample-name>
dotnet build
# Should see: Build succeeded. 0 Warning(s). 0 Error(s).

# 2. Run succeeds
dotnet watch run
# Should see: Now listening on: http://localhost:5000

# 3. Test in browser
# Open browser to http://localhost:5000/scalar
# - Scalar UI should load
# - Endpoints should be listed
# - Click on endpoint, should see parameters and descriptions

# 4. Test OpenAPI document
# Navigate to http://localhost:5000/openapi/v1.json
# - Should see valid JSON
# - Should include endpoint descriptions from XML comments

# 5. Stop the app
# Press Ctrl+C in terminal

# 6. Return to root
cd /mnt/d/GitHub/practical-aspnetcore
```

**Common issues:**
- **Error:** "XML documentation file not found" → Check `GenerateDocumentationFile` in .csproj
- **Error:** "Scalar UI not found" → Check `Scalar.AspNetCore` package is installed
- **Error:** "OpenAPI document empty" → Check `builder.Services.AddOpenApi()` is called

### For SSE Sample

```bash
# 1. Build and run
cd projects/sse
dotnet build
dotnet watch run

# 2. Test in browser
# Navigate to http://localhost:5000/
# - Page should load with empty list
# - Open browser console (F12)
# - Should see: "Connecting to SSE..."
# - Should see: "Connection opened:"
# - List items should appear every 3 seconds
# - Each item should say "hello world X"

# 3. Stop the app
# Press Ctrl+C

# 4. Return to root
cd /mnt/d/GitHub/practical-aspnetcore
```

### For IHostedService Sample

```bash
# 1. Build and run
cd projects/ihosted-service/ihosted-service-1
dotnet build
dotnet watch run

# 2. Test in browser
# Navigate to http://localhost:5000/
# - Should see: "Please reload page (greeting updated every 1 second in the background) Hello world 0"
# - Reload the page
# - Counter should have incremented
# - Example: "Hello world 5" (if 5 seconds passed)

# 3. Stop the app
# Press Ctrl+C

# 4. Return to root
cd /mnt/d/GitHub/practical-aspnetcore
```

---

## Commit Messages

### Message Format

```
<action> <sample-path> to .NET 10 <feature>

- <change 1>
- <change 2>
- <change 3>

Refs: OUT-OF-DATE.md - <category>
```

### Individual Commit Messages

#### Commit 1: open-api-1
```bash
git commit -m "Migrate minimal-api/open-api-1 to .NET 10 built-in OpenAPI

- Replace Swashbuckle.AspNetCore with Microsoft.AspNetCore.OpenApi 10.0.0-preview
- Add Scalar.AspNetCore for modern API documentation UI
- Remove deprecated WithOpenApi() extension method
- Add XML doc comments for endpoint descriptions
- Update .csproj: enable GenerateDocumentationFile
- Update README.md with built-in OpenAPI notes

Refs: OUT-OF-DATE.md - Category 1: Swashbuckle/OpenAPI Samples"
```

#### Commit 2: open-api-2
```bash
git commit -m "Migrate minimal-api/open-api-2 to .NET 10 built-in OpenAPI

- Replace Swashbuckle.AspNetCore with Microsoft.AspNetCore.OpenApi 10.0.0-preview
- Add Scalar.AspNetCore for modern API documentation UI
- Remove deprecated WithOpenApi() extension method
- Add XML doc comments for endpoint descriptions and responses
- Update .csproj: enable GenerateDocumentationFile
- Update README.md with built-in OpenAPI notes

Refs: OUT-OF-DATE.md - Category 1: Swashbuckle/OpenAPI Samples"
```

#### Commit 3: map-group-2
```bash
git commit -m "Migrate minimal-api/map-group-2 to .NET 10 built-in OpenAPI

- Replace Swashbuckle.AspNetCore with Microsoft.AspNetCore.OpenApi 10.0.0-preview
- Add Scalar.AspNetCore for modern API documentation UI
- Update .csproj: enable GenerateDocumentationFile
- Update README.md with built-in OpenAPI notes

Refs: OUT-OF-DATE.md - Category 1: Swashbuckle/OpenAPI Samples"
```

#### Commit 4: map-group-3
```bash
git commit -m "Migrate minimal-api/map-group-3 to .NET 10 built-in OpenAPI

- Replace Swashbuckle.AspNetCore with Microsoft.AspNetCore.OpenApi 10.0.0-preview
- Add Scalar.AspNetCore for modern API documentation UI
- Update .csproj: enable GenerateDocumentationFile
- Update README.md with built-in OpenAPI notes

Refs: OUT-OF-DATE.md - Category 1: Swashbuckle/OpenAPI Samples"
```

#### Commit 5: map-4
```bash
git commit -m "Migrate minimal-api/map-4 to .NET 10 built-in OpenAPI

- Replace Swashbuckle.AspNetCore with Microsoft.AspNetCore.OpenApi 10.0.0-preview
- Add Scalar.AspNetCore for modern API documentation UI
- Update .csproj: enable GenerateDocumentationFile
- Update README.md with built-in OpenAPI notes

Refs: OUT-OF-DATE.md - Category 1: Swashbuckle/OpenAPI Samples"
```

#### Commit 6: pokedex
```bash
git commit -m "Migrate pokedex to .NET 10 built-in OpenAPI

- Replace Swashbuckle.AspNetCore with Microsoft.AspNetCore.OpenApi 10.0.0-preview
- Add Scalar.AspNetCore for modern API documentation UI
- Update .csproj: enable GenerateDocumentationFile
- Update README.md with built-in OpenAPI notes

Refs: OUT-OF-DATE.md - Category 1: Swashbuckle/OpenAPI Samples"
```

#### Commit 7: authentication-4
```bash
git commit -m "Migrate authentication-4 to .NET 10 built-in OpenAPI

- Replace Swashbuckle.AspNetCore with Microsoft.AspNetCore.OpenApi 10.0.0-preview
- Add Scalar.AspNetCore for modern API documentation UI
- Update .csproj: enable GenerateDocumentationFile
- Update README.md with built-in OpenAPI notes

Refs: OUT-OF-DATE.md - Category 1: Swashbuckle/OpenAPI Samples"
```

#### Commit 8: authentication-5
```bash
git commit -m "Migrate authentication-5 to .NET 10 built-in OpenAPI

- Replace Swashbuckle.AspNetCore with Microsoft.AspNetCore.OpenApi 10.0.0-preview
- Add Scalar.AspNetCore for modern API documentation UI
- Remove deprecated WithOpenApi() extension method
- Add XML doc comments for endpoint descriptions
- Update .csproj: enable GenerateDocumentationFile
- Update README.md with built-in OpenAPI notes

Refs: OUT-OF-DATE.md - Category 1: Swashbuckle/OpenAPI Samples"
```

#### Commit 9: nswag
```bash
git commit -m "Migrate mvc/nswag to .NET 10 built-in OpenAPI with MVC

- Replace NSwag.AspNetCore with Microsoft.AspNetCore.OpenApi 10.0.0-preview
- Add Scalar.AspNetCore for modern API documentation UI
- Add XML doc comments to controller actions
- Update .csproj: enable GenerateDocumentationFile
- Update README.md with built-in OpenAPI notes

Refs: OUT-OF-DATE.md - Category 1: Swashbuckle/OpenAPI Samples"
```

#### Commit 10: nswag-2
```bash
git commit -m "Migrate mvc/nswag-2 to .NET 10 built-in OpenAPI with MVC

- Replace NSwag.AspNetCore with Microsoft.AspNetCore.OpenApi 10.0.0-preview
- Add Scalar.AspNetCore for modern API documentation UI
- Add XML doc comments to controller actions
- Update .csproj: enable GenerateDocumentationFile
- Update README.md with built-in OpenAPI notes

Refs: OUT-OF-DATE.md - Category 1: Swashbuckle/OpenAPI Samples"
```

#### Commit 11: sse
```bash
git commit -m "Migrate sse sample to .NET 10 built-in Server-Sent Events

- Replace manual SSE protocol implementation with Results.ServerSentEvents()
- Use IAsyncEnumerable<string> with proper cancellation token handling
- Add [EnumeratorCancellation] attribute for proper cancellation
- Remove manual Response.WriteAsync() and FlushAsync() calls
- Simplify code with automatic flush management
- Update README.md with built-in SSE notes

Refs: OUT-OF-DATE.md - Category 2: Server-Sent Events"
```

#### Commit 12: ihosted-service-1
```bash
git commit -m "Simplify ihosted-service-1 using BackgroundService base class

- Remove custom HostedService abstract base class (40+ lines of boilerplate)
- Inherit from Microsoft.Extensions.Hosting.BackgroundService
- Update service registration to use AddHostedService<T>()
- Cleaner cancellation token handling via stoppingToken parameter
- Update README.md with BackgroundService pattern notes

Refs: OUT-OF-DATE.md - Category 3: IHostedService Patterns"
```

#### Commit 13: Documentation Update
```bash
git commit -m "Update documentation to reflect .NET 10 migrations

- Update root README.md with note about .NET 10 modern patterns
- Update projects/minimal-api/README.md with OpenAPI migration notes
- Update projects/authentication/README.md with OpenAPI migration notes
- Update projects/sse/README.md with built-in SSE notes
- Update projects/mvc/README.md with NSwag alternative notes
- Update projects/ihosted-service/README.md with BackgroundService pattern notes
- Mark OUT-OF-DATE.md as completed

Refs: OUT-OF-DATE.md"
```

---

## Sample-by-Sample Execution Guide

### Sample 1: minimal-api/open-api-1

**Location:** `projects/minimal-api/open-api-1/`

**Files to update:**
- `open-api-1.csproj`
- `Program.cs`
- `README.md`

**Steps:**
```bash
cd projects/minimal-api/open-api-1

# Read current files
cat open-api-1.csproj
cat Program.cs
cat README.md

# Update .csproj (see Pattern A, Step 1)
# Update Program.cs (see Pattern A, Step 2)
# Update README.md (see Pattern A, Step 3)

# Test
dotnet build
dotnet watch run
# Test in browser: /scalar and /openapi/v1.json
# Press Ctrl+C to stop

cd /mnt/d/GitHub/practical-aspnetcore

# Commit
git add projects/minimal-api/open-api-1/
git commit -m "Migrate minimal-api/open-api-1 to .NET 10 built-in OpenAPI

- Replace Swashbuckle.AspNetCore with Microsoft.AspNetCore.OpenApi 10.0.0-preview
- Add Scalar.AspNetCore for modern API documentation UI
- Remove deprecated WithOpenApi() extension method
- Add XML doc comments for endpoint descriptions
- Update .csproj: enable GenerateDocumentationFile
- Update README.md with built-in OpenAPI notes

Refs: OUT-OF-DATE.md - Category 1: Swashbuckle/OpenAPI Samples"

# Verify
git log -1 --stat
```

### Sample 2: minimal-api/open-api-2

**Location:** `projects/minimal-api/open-api-2/`

**Steps:** Same as Sample 1, but use commit message for open-api-2

### Sample 3: minimal-api/map-group-2

**Location:** `projects/minimal-api/map-group-2/`

**Steps:** Same as Sample 1, but use commit message for map-group-2

### Sample 4: minimal-api/map-group-3

**Location:** `projects/minimal-api/map-group-3/`

**Steps:** Same as Sample 1, but use commit message for map-group-3

### Sample 5: minimal-api/map-4

**Location:** `projects/minimal-api/map-4/`

**Steps:** Same as Sample 1, but use commit message for map-4

### Sample 6: pokedex

**Location:** `projects/mini/minimal-api-pokedex/src/Minimal.Api.Pokedex/`

**Note:** This is a multi-project sample. Update the main API project.

**Steps:**
```bash
cd projects/mini/minimal-api-pokedex/src/Minimal.Api.Pokedex

# Read current files
cat Minimal.Api.Pokedex.csproj
cat Program.cs

# Update .csproj and Program.cs using Pattern A

# Test
dotnet build
dotnet watch run
# Test in browser
# Press Ctrl+C

cd /mnt/d/GitHub/practical-aspnetcore

# Commit
git add projects/mini/minimal-api-pokedex/
git commit -m "Migrate pokedex to .NET 10 built-in OpenAPI

- Replace Swashbuckle.AspNetCore with Microsoft.AspNetCore.OpenApi 10.0.0-preview
- Add Scalar.AspNetCore for modern API documentation UI
- Update .csproj: enable GenerateDocumentationFile
- Update README.md with built-in OpenAPI notes

Refs: OUT-OF-DATE.md - Category 1: Swashbuckle/OpenAPI Samples"
```

### Sample 7: authentication/authentication-4

**Location:** `projects/authentication/authentication-4/`

**Steps:** Same as Sample 1, but use commit message for authentication-4

### Sample 8: authentication/authentication-5

**Location:** `projects/authentication/authentication-5/`

**Steps:** Same as Sample 1, but use commit message for authentication-5

### Sample 9: mvc/nswag

**Location:** `projects/mvc/nswag/`

**Steps:**
```bash
cd projects/mvc/nswag

# Read current files
cat nswag.csproj
cat Program.cs

# Update .csproj (see Pattern A, Step 1 - remove NSwag, add Scalar)
# Update Program.cs (see Pattern A, Step 2 - for MVC)
# Add XML comments to controller actions

# Test
dotnet build
dotnet watch run
# Test in browser: /scalar
# Press Ctrl+C

cd /mnt/d/GitHub/practical-aspnetcore

# Commit
git add projects/mvc/nswag/
git commit -m "Migrate mvc/nswag to .NET 10 built-in OpenAPI with MVC

- Replace NSwag.AspNetCore with Microsoft.AspNetCore.OpenApi 10.0.0-preview
- Add Scalar.AspNetCore for modern API documentation UI
- Add XML doc comments to controller actions
- Update .csproj: enable GenerateDocumentationFile
- Update README.md with built-in OpenAPI notes

Refs: OUT-OF-DATE.md - Category 1: Swashbuckle/OpenAPI Samples"
```

### Sample 10: mvc/nswag-2

**Location:** `projects/mvc/nswag-2/`

**Steps:** Same as Sample 9, but use commit message for nswag-2

### Sample 11: sse

**Location:** `projects/sse/`

**Steps:**
```bash
cd projects/sse

# Read current file
cat Program.cs

# Update Program.cs (see Pattern B, Step 1)
# Update README.md (see Pattern B, Step 2)

# Test
dotnet build
dotnet watch run
# Test in browser: http://localhost:5000/
# Open console, verify SSE events
# Press Ctrl+C

cd /mnt/d/GitHub/practical-aspnetcore

# Commit
git add projects/sse/
git commit -m "Migrate sse sample to .NET 10 built-in Server-Sent Events

- Replace manual SSE protocol implementation with Results.ServerSentEvents()
- Use IAsyncEnumerable<string> with proper cancellation token handling
- Add [EnumeratorCancellation] attribute for proper cancellation
- Remove manual Response.WriteAsync() and FlushAsync() calls
- Simplify code with automatic flush management
- Update README.md with built-in SSE notes

Refs: OUT-OF-DATE.md - Category 2: Server-Sent Events"
```

### Sample 12: ihosted-service/ihosted-service-1

**Location:** `projects/ihosted-service/ihosted-service-1/`

**Steps:**
```bash
cd projects/ihosted-service/ihosted-service-1

# Read current file
cat Program.cs

# Update Program.cs (see Pattern C, Step 1)
# Update README.md (see Pattern C, Step 2)

# Test
dotnet build
dotnet watch run
# Test in browser: http://localhost:5000/
# Reload page, counter should increment
# Press Ctrl+C

cd /mnt/d/GitHub/practical-aspnetcore

# Commit
git add projects/ihosted-service/ihosted-service-1/
git commit -m "Simplify ihosted-service-1 using BackgroundService base class

- Remove custom HostedService abstract base class (40+ lines of boilerplate)
- Inherit from Microsoft.Extensions.Hosting.BackgroundService
- Update service registration to use AddHostedService<T>()
- Cleaner cancellation token handling via stoppingToken parameter
- Update README.md with BackgroundService pattern notes

Refs: OUT-OF-DATE.md - Category 3: IHostedService Patterns"
```

### Sample 13: Documentation Update

**Location:** Root and category READMEs

**Steps:**
```bash
# Update root README.md
# Add a section about .NET 10 modern patterns after the introduction

# Update category READMEs:
# - projects/minimal-api/README.md
# - projects/authentication/README.md
# - projects/sse/README.md
# - projects/mvc/README.md
# - projects/ihosted-service/README.md

# For each category README, add a note:
# "Note: Samples have been migrated to use .NET 10 built-in features. See MIGRATION-PLAN.md for details."

# Update or remove OUT-OF-DATE.md
# Option 1: Add at top: "STATUS: MIGRATION COMPLETED (2026-03-06)"
# Option 2: Delete the file

# Commit
git add README.md
git add projects/*/README.md
git add OUT-OF-DATE.md

git commit -m "Update documentation to reflect .NET 10 migrations

- Update root README.md with note about .NET 10 modern patterns
- Update projects/minimal-api/README.md with OpenAPI migration notes
- Update projects/authentication/README.md with OpenAPI migration notes
- Update projects/sse/README.md with built-in SSE notes
- Update projects/mvc/README.md with NSwag alternative notes
- Update projects/ihosted-service/README.md with BackgroundService pattern notes
- Mark OUT-OF-DATE.md as completed

Refs: OUT-OF-DATE.md"
```

---

## Final Verification

### After All 13 Commits

```bash
# 1. Check commit history
git log --oneline -13

# Should see all 13 commits in reverse chronological order

# 2. Verify no uncommitted changes
git status
# Should say: "nothing to commit, working tree clean"

# 3. Optional: Build all migrated samples
cd projects/minimal-api/open-api-1 && dotnet build && cd ../../..
cd projects/minimal-api/open-api-2 && dotnet build && cd ../../..
cd projects/minimal-api/map-group-2 && dotnet build && cd ../../..
cd projects/minimal-api/map-group-3 && dotnet build && cd ../../..
cd projects/minimal-api/map-4 && dotnet build && cd ../../..
cd projects/mini/minimal-api-pokedex/src/Minimal.Api.Pokedex && dotnet build && cd ../../../../..
cd projects/authentication/authentication-4 && dotnet build && cd ../../..
cd projects/authentication/authentication-5 && dotnet build && cd ../../..
cd projects/mvc/nswag && dotnet build && cd ../..
cd projects/mvc/nswag-2 && dotnet build && cd ../..
cd projects/sse && dotnet build && cd ../..
cd projects/ihosted-service/ihosted-service-1 && dotnet build && cd ../../..

# 4. If using feature branch, push to remote
git push origin migrate-to-net10-patterns

# 5. If ready to merge to main
git checkout main
git merge migrate-to-net10-patterns
git push origin main
```

---

## Success Criteria

Before marking this migration as complete, verify:

- [ ] All 13 commits created with descriptive messages
- [ ] Each commit is atomic (all files for that sample in one commit)
- [ ] All 12 samples build without warnings (`dotnet build` succeeds)
- [ ] All 12 samples run correctly (`dotnet watch run` succeeds)
- [ ] OpenAPI samples: `/scalar` and `/openapi/v1.json` accessible (10 samples)
- [ ] SSE sample: Events received in browser every 3 seconds
- [ ] IHostedService sample: Counter increments every second
- [ ] No deprecated `WithOpenApi()` usage remains
- [ ] No `Swashbuckle.AspNetCore` or `NSwag.AspNetCore` packages remain
- [ ] All READMEs updated with migration notes
- [ ] Git history shows clear, traceable progression
- [ ] `git log --oneline -13` shows all commits
- [ ] `git status` shows clean working tree
- [ ] Root README and category READMEs updated in final commit
- [ ] OUT-OF-DATE.md marked as completed or removed

---

## Troubleshooting

### Common Issues

#### Issue: "Cannot find type 'BackgroundService'"

**Solution:** Add `using Microsoft.Extensions.Hosting;` at top of Program.cs

#### Issue: "XML documentation file not found"

**Solution:** Add to .csproj:
```xml
<GenerateDocumentationFile>true</GenerateDocumentationFile>
```

#### Issue: "Scalar UI not loading"

**Solution:** Check that:
1. `Scalar.AspNetCore` package is installed
2. `app.MapScalarApiReference();` is called after `app.Build()`
3. Navigate to `/scalar` (not `/swagger`)

#### Issue: "OpenAPI document is empty"

**Solution:** Check that:
1. `builder.Services.AddOpenApi();` is called
2. `app.MapOpenApi();` is called
3. At least one endpoint is mapped

#### Issue: "SSE events not appearing"

**Solution:** Check that:
1. `using System.Runtime.CompilerServices;` is added
2. `[EnumeratorCancellation]` attribute is on the cancellation token parameter
3. Browser is sending `Accept: text/event-stream` header

#### Issue: "Build fails after migration"

**Solution:** 
1. Check .csproj for correct package versions
2. Run `dotnet restore`
3. Delete `bin/` and `obj/` folders and rebuild

---

## Reference Links

### Official Documentation
- [.NET 10 What's New](https://learn.microsoft.com/dotnet/core/whats-new/dotnet-10)
- [ASP.NET Core 10 What's New](https://learn.microsoft.com/aspnet/core/release-notes/aspnetcore-10)
- [Built-in OpenAPI Support](https://learn.microsoft.com/aspnet/core/fundamentals/openapi/aspnetcore-openapi)
- [Server-Sent Events](https://learn.microsoft.com/aspnet/core/fundamentals/server-sent-events)
- [BackgroundService Class](https://learn.microsoft.com/dotnet/api/microsoft.extensions.hosting.backgroundservice)

### Internal References
- `OUT-OF-DATE.md` - Original analysis of outdated samples
- `projects/net10/README.md` - .NET 10 feature samples index
- `projects/net10/open-api-8/` - Reference for built-in OpenAPI pattern
- `projects/net10/sse-2/` - Reference for built-in SSE pattern
- `AGENTS.md` - Repository conventions and guidelines

---

## Notes for Future Agents

1. **This plan is self-contained** - All information needed to execute the migration is in this file.

2. **Follow the order** - Execute samples in the order listed (1-13) for best results.

3. **Test before commit** - Always run `dotnet build` and `dotnet watch run` before committing.

4. **Use the exact commit messages** - Copy-paste the commit messages to ensure consistency.

5. **One sample at a time** - Don't try to batch multiple samples in one commit.

6. **Reference existing .NET 10 samples** - If unsure, look at `projects/net10/open-api-8/` or `projects/net10/sse-2/` for patterns.

7. **Keep it simple** - The goal is to demonstrate modern patterns with minimal code.

8. **Update READMEs** - Don't skip updating README.md files - they help users understand the changes.

9. **Mark complete** - After finishing, update this file with completion status.

---

## Completion Checklist

When finished, update this section:

- [ ] **Started:** (date)
- [ ] **Completed:** (date)
- [ ] **Commits created:** X/13
- [ ] **Samples migrated:** X/12
- [ ] **Documentation updated:** Yes/No
- [ ] **Tested all samples:** Yes/No
- [ ] **Pushed to remote:** Yes/No (branch name: ________)
- [ ] **Merged to main:** Yes/No

**Notes:**
(Add any notes about issues encountered, deviations from plan, etc.)

---

**End of Migration Plan**
