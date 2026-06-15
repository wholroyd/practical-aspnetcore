var builder = WebApplication.CreateBuilder();

var app = builder.Build();

app.MapGet("/", () =>
{
    var html = """
    <html>
    <body>
        <h1>Memory Pool Eviction Demo</h1>
        <p>.NET 10 automatically evicts idle memory from pools.</p>
        <ul>
            <li><a href="/allocate">Allocate 1MB</a></li>
            <li><a href="/stats">Memory Statistics</a></li>
        </ul>
        <p>After allocation, wait a moment, then call /stats to see memory usage.</p>
    </body>
    </html>
    """;
    return Results.Content(html, "text/html");
});

app.MapGet("/allocate", () =>
{
    var data = new byte[1024 * 1024];
    return Results.Ok(new { Allocated = data.Length });
});

app.MapGet("/stats", () =>
{
    var totalMemory = GC.GetTotalMemory(false);
    return Results.Ok(new
    {
        TotalMemoryBytes = totalMemory,
        TotalMemoryMB = totalMemory / 1024 / 1024
    });
});

app.Run();
