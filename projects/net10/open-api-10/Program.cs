using Microsoft.AspNetCore.Http.HttpResults;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder();

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference();

app.MapGet("/", () =>
{
    var html = """
    <html>
    <body>
        <h1>OpenAPI JSON document - use response XML comment tag to annotate API</h1>
        <ul>
            <li>
                You can check the generated OpenAPI document <a href="/openapi/v1.json">here</a>.
            </li>
            <li>
                You can check the Scalar UI <a href="/scalar">here</a>.
            </li>
    </body>
    </html>
    """;

    return TypedResults.Content(html, "text/html");
}).ExcludeFromDescription(); //This is not an API endpoint

app.MapGet("/hello/{name}",  Hello);

app.Run();


static partial class Program
{
    ///<summary>
    /// Returns a greeting message
    /// </summary>
    /// <remarks>
    /// This is a sample endpoint that returns a greeting message.
    /// </remarks>
    /// <response code="200">Returns a greeting message</response>
    /// <response code="500">Show error message</response>
    /// <param name="name">The name of the person to greet</param>
    public static Results<Ok<string>, InternalServerError<string>> Hello(string name)
    {
        try
        {
            return TypedResults.Ok($"Hello, {name}");
        }
        catch
        {
            return TypedResults.InternalServerError("An error occurred while processing your request.");
        }
    }
}
