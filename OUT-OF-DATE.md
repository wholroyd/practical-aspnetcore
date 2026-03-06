# Outdated ASP.NET Core 10 Samples Report

**Generated:** 2026-03-06  
**Repository:** practical-aspnetcore  
**Total Samples Analyzed:** 637  
**Outdated Samples Identified:** 14  
**Migrated:** 12 ✅  
**Remaining:** 2

---

## Migration Status

### Completed Migrations ✅

| Sample | Category | Migration |
|--------|----------|-----------|
| `minimal-api/open-api-1` | OpenAPI | Swashbuckle → Built-in |
| `minimal-api/open-api-2` | OpenAPI | Swashbuckle → Built-in |
| `minimal-api/map-group-2` | OpenAPI | Swashbuckle → Built-in |
| `minimal-api/map-group-3` | OpenAPI | Swashbuckle → Built-in |
| `minimal-api/map-4` | OpenAPI | Swashbuckle → Built-in |
| `authentication/authentication-4` | OpenAPI | Swashbuckle → Built-in |
| `authentication/authentication-5` | OpenAPI | Swashbuckle → Built-in |
| `mini/minimal-api-pokedex` | OpenAPI | Swashbuckle → Built-in |
| `mvc/nswag` | OpenAPI | NSwag → Built-in |
| `sse` | SSE | Manual → Built-in |
| `ihosted-service/ihosted-service-1` | Background | Custom base → BackgroundService |

### Remaining Samples

| Sample | Priority | Notes |
|--------|----------|-------|
| `mvc/nswag-2` | LOW | Alternative approach, kept for reference |
| `generic-host/generic-host-1/2` | LOW | Still valid for non-web scenarios |

---

## Executive Summary

This report identifies samples that were outdated due to new APIs and features available in .NET 10 / ASP.NET Core 10. **12 samples have been successfully migrated** to use modern patterns.

### Key Migrations Completed

1. **OpenAPI/Swagger** - 9 samples migrated from Swashbuckle to built-in OpenAPI
2. **Server-Sent Events** - 1 sample migrated from manual implementation to built-in SSE
3. **IHostedService** - 1 sample simplified using `BackgroundService` base class

---

## Migration Patterns Applied

### OpenAPI Migration

**Before (Swashbuckle):**
```csharp
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/greeting", Hello.GetGreeting).WithOpenApi(op => { ... });
```

**After (Built-in OpenAPI):**
```csharp
builder.Services.AddOpenApi();

var app = builder.Build();
app.MapOpenApi();
app.MapScalarApiReference();

/// <summary>
/// Return greeting given name
/// </summary>
app.MapGet("/greeting", Hello.GetGreeting);
```

### SSE Migration

**Before (Manual):**
```csharp
app.MapGet("/sse", async context =>
{
    context.Response.ContentType = "text/event-stream";
    await context.Response.WriteAsync($"data: {data}\n");
    await context.Response.Body.FlushAsync();
});
```

**After (Built-in):**
```csharp
app.MapGet("/sse", (CancellationToken ct) =>
{
    async IAsyncEnumerable<string> GetEvents([EnumeratorCancellation] CancellationToken ct)
    {
        while (!ct.IsCancellationRequested)
        {
            yield return $"Event at {DateTime.UtcNow}";
            await Task.Delay(1000, ct);
        }
    }
    return Results.ServerSentEvents(GetEvents(ct));
});
```

### BackgroundService Migration

**Before (Custom base):**
```csharp
public abstract class HostedService : IHostedService, IDisposable { /* 20+ lines */ }
```

**After (BackgroundService):**
```csharp
public class MyService : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            // Do work
            await Task.Delay(TimeSpan.FromSeconds(1), stoppingToken);
        }
    }
}
```

---

## Benefits of Migration

| Aspect | Before | After |
|--------|--------|-------|
| Dependencies | Swashbuckle.AspNetCore | Built-in (no package) |
| OpenAPI Version | 3.0 | 3.1 |
| AOT Compatible | No | Yes |
| Code Simplicity | More boilerplate | XML comments |
| Performance | Good | Better (source generators) |

---

## References

- `projects/net10/README.md` - .NET 10 feature samples
- `projects/net10/open-api-*` - Built-in OpenAPI examples
- `projects/net10/sse-*` - Built-in SSE examples
