# Built-in Server-Sent Events

This sample demonstrates ASP.NET Core 10's built-in Server-Sent Events (SSE) support using `Results.ServerSentEvents()`.

## Running the Sample

```bash
dotnet watch run
```

Navigate to `http://localhost:5000/` to see the SSE client in action.

## Key Features

- Built-in SSE support via `Results.ServerSentEvents()`
- Type-safe with `IAsyncEnumerable<string>`
- Automatic flush management
- Proper cancellation token handling
- No manual protocol implementation needed

## How It Works

The endpoint returns `Results.ServerSentEvents()` with an `IAsyncEnumerable<string>`:

```csharp
app.MapGet("/sse", (HttpContext context, CancellationToken cancellationToken) =>
{
    async IAsyncEnumerable<string> CounterAsync([EnumeratorCancellation] CancellationToken cancellationToken)
    {
        int count = 0;
        while (true && !cancellationToken.IsCancellationRequested)
        {
            yield return $"hello world {++count}";
            await Task.Delay(3000, cancellationToken);
        }
    }

    if (context.Request.Headers["Accept"] == "text/event-stream")
    {
        return Results.ServerSentEvents(CounterAsync(cancellationToken), eventType: "greeting");
    }
    else
    {
        return Results.BadRequest("Unsupported Accept header. Use 'text/event-stream'.");
    }
});

app.MapGet("/", async context =>
{
    await context.Response.WriteAsync(@"
<html>
    <head>
    </head>
    <body>
        <h1>SSE with Built-in Support</h1>
        <ul id="list""></ul>
        <script>
            console.log('Connecting to SSE...');
            var source = new EventSource('/sse');
            source.onopen = function(event) {
                console.log('Connection opened:', event);
            };
            source.onmessage = function(e) {
                var item = document.createElement('li');
                item.textContent = e.data;
                list.appendChild(item);
            };
            source.onerror = function(event) {
                console.log(event);
            }
        </script>
    </body>
</html>
    ");
});

app.Run();