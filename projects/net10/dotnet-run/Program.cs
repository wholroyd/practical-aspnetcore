#:sdk Microsoft.NET.Sdk.Web
#:package markdig@0.41.1
using Markdig;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();
app.MapGet("/", () =>
{
    var content = """
    This is a project-less **ASP.NET Core** web application.
    """;

    return Results.Content($"""
    <html><body>{Markdown.ToHtml(content)}</body></html>
    """, "text/html");
});

app.Run();