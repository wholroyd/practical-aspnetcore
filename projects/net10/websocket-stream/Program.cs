using System.Net.WebSockets;

var builder = WebApplication.CreateBuilder();

var app = builder.Build();

app.UseWebSockets();

app.MapGet("/", async context =>
{
    await context.Response.WriteAsync("""
    <html>
    <head>
        <title>WebSocket Echo Demo</title>
    </head>
    <body>
        <h1>WebSocket Echo Demo</h1>
        <p>Connect to the WebSocket endpoint and send messages.</p>
        <button onclick="connect()">Connect</button>
        <button onclick="send()">Send Message</button>
        <ul id="messages"></ul>
        <script>
            let ws;
            function connect() {
                ws = new WebSocket((location.protocol === 'https:' ? 'wss:' : 'ws:') + '//' + location.host + '/ws');
                ws.onopen = () => {
                    var item = document.createElement('li');
                    item.textContent = 'Connected';
                    messages.appendChild(item);
                };
                ws.onmessage = e => {
                    var item = document.createElement('li');
                    item.textContent = e.data;
                    messages.appendChild(item);
                };
                ws.onclose = () => {
                    var item = document.createElement('li');
                    item.textContent = 'Disconnected';
                    messages.appendChild(item);
                }
            }
            function send() {
                if (ws && ws.readyState === WebSocket.OPEN) {
                    ws.send('Hello from client');
                }
            }
        </script>
    </body>
    </html>
    """);
});

app.MapGet("/ws", async context =>
{
    if (!context.WebSockets.IsWebSocketRequest)
    {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
        return;
    }

    using var webSocket = await context.WebSockets.AcceptWebSocketAsync();
    
    var buffer = new byte[1024];
    var receiveResult = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
    
    while (!receiveResult.CloseStatus.HasValue)
    {
        var message = System.Text.Encoding.UTF8.GetString(buffer, 0, receiveResult.Count);
        var echoMessage = $"Echo: {message}";
        var echoBytes = System.Text.Encoding.UTF8.GetBytes(echoMessage);
        await webSocket.SendAsync(new ArraySegment<byte>(echoBytes), receiveResult.MessageType, receiveResult.EndOfMessage, CancellationToken.None);
        receiveResult = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
    }

    await webSocket.CloseAsync(receiveResult.CloseStatus.Value, receiveResult.CloseStatusDescription, CancellationToken.None);
});

app.Run();
