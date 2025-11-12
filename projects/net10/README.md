# ASP.NET Core 10 (12)

These samples require SDK [10.0.100](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)

- [dotnet run](dotnet-run)

  This is a sample code on how you can build an ASP.NET Core application using the new .NET 10 project-less `dotnet run xxx.cs` functionality.

- [open-api-8](open-api-8)

  This sample shows how to populate OpenAPI document with metadata from XML doc comments on methods, class, and members.

- [open-api-9](open-api-9)

  This sample shows how to generate OpenAPI documentation YAML format.

- [open-api-10](open-api-10)

  This sample shows how to populate OpenAPI document responses information with XML doc comment `response` element.

- [open-api-11](open-api-11)

  This sample shows how to populate OpenAPI document response 200 information with XML doc comment `returns` element.

- [redirect-http-result-is-local-url](redirect-http-result-is-local-url)

  This sample how to use `RedirectHttpResult.IsLocalUrl` to detect if a URL is local.

- [sse-2](sse-2)

  Use `Results.ServerSentEvents` to return Server Side Events on Minimal API.

- [sse-3](sse-3)

  Use `Results.ServerSentEvents` to return Server Side Events with Event Type on Minimal API.

- [sse-4](sse-4)

  Use `Results.ServerSentEvents` to return Server Side Events with mixed events on Minimal API.


## Validation

- [validation-1](validation-1)

  This example shows how the to validate complex object bound with the route via `[AsParameter]` attribute.

- [validation-2](validation-2)

  This time we implement `IValidatableObject` to implement custom validation logic. 

- [validation-3](validation-3)
  
  This is a demo that show how built-in validation works in [FromForm] scenario but it can't really be used in a straight HTML serving scenario because right now there is no way to obtain the validation results.