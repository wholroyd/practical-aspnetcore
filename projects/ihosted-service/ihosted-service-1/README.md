# BackgroundService Pattern

This sample demonstrates using the `BackgroundService` base class for background tasks in ASP.NET Core.

## Running the Sample

```bash
dotnet watch run
```

Navigate to `http://localhost:5000/` and see the counter incrementing every second in the background). A `GreeterUpdaterService` updates a `Greeter` singleton every second.

 the updates are visible on.
 `Greeter` class provides the greeting data to the background task.

 The sample uses dependency injection to the `GreeterUpdaterService` injects the `Greeter` singleton. The service also automatically updates the counter property.

## Key Features

- Built-in `BackgroundService` base class for background tasks
- Much less code than custom `IHostedService` implementation
- Proper cancellation token handling
- Cleaner, more maintainable code
- Standard pattern recommended by Microsoft

## Running the Sample

```bash
dotnet watch run
```

Navigate to `http://localhost:5000/` and see the counter incrementing every second in the background) a `Greeter` service updates a `Greeter` singleton.

## Registration

```csharp
builder.Services.AddSingleton<Greeter>();
builder.Services.AddHostedService<GreeterUpdaterService>();
```

## Viewing the Documentation

- **Scalar UI:** Navigate to `/scalar`
- **OpenAPI JSON:** Navigate to `/openapi/v1.json`

## Migration Notes

This sample was simplified from a custom `IHostedService` implementation to using the built-in `BackgroundService` base class.
- Removed custom `HostedService` abstract base class (40+ lines of boilerplate)
- Inherited from `Microsoft.Extensions.Hosting.BackgroundService`
- Simplified cancellation token handling
- Cleaner, more maintainable code
- Standard pattern recommended by Microsoft

See `OUT-OF-DATE.md` for migration details.
