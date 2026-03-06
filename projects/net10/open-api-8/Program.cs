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
        <h1>OpenAPI JSON document</h1>
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
    /// <param name="name">The name of the person to greet</param>
    public static string Hello(string name)
    {
        return $"Hello, {name}";
    }
}
