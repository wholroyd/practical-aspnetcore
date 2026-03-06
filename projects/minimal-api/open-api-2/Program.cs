using Microsoft.AspNetCore.Http.HttpResults;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder();
builder.Services.AddOpenApi();

var app = builder.Build();
app.MapOpenApi();
app.MapScalarApiReference();

app.MapGet("/", () => Results.Content("""
<html>
<head>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-0evHe/X+R7YkIZDRvuzKMRqM+OrBnVFBL6DOitfPri4tjfHxaWutUpFmBp4vmVor" crossorigin="anonymous">
</head>
<body>
    <div class="container">
        <ul>
            <li><a href="/scalar">Scalar API Documentation</a></li>
            <li><a href="/openapi/v1.json">OpenAPI JSON</a></li>
        </ul>
    </div>
</body>
</html>
""", "text/html"));

app.MapGet("/greeting", Hello.GetGreeting);

app.Run();

public record Person(string Name);

/// <summary>
/// Return greeting given name
/// </summary>
public static class Hello
{
    /// <param name="name">The name of the person to greet</param>
    /// <response code="200">Returns the person with the greeting</response>
    /// <response code="404">If name is null or whitespace</response>
    public static Results<Ok<Person>, NotFound> GetGreeting(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return TypedResults.NotFound();
        
        return TypedResults.Ok(new Person(name));
    } 
}
