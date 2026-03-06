using Microsoft.Extensions.Hosting;

using Microsoft.Extensions.Hosting;

using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder();
builder.Services.AddSingleton<Greeter>();
builder.Services.AddHostedService<GreeterUpdaterService>();

var app = builder.Build();
app.Run(context =>
{
    var greet = context.RequestServices.GetService<Greeter>();

    return context.Response.WriteAsync($"Please reload page (greeting updated every 1 second in the background) {greet}");
});

app.Run();

public class Greeter
{
    public int Counter { get; set; }
    public override string ToString() => $"Hello world {Counter}";
    }
}

/// <summary>
/// Background service that updates a Greeter counter
/// </summary>
public class GreeterUpdaterService : BackgroundService
{
    private readonly Greeter _greeter;

    public GreeterUpdaterService(Greeter greeter)
    {
        _greeter = greeter;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _greeter.Counter++;
            await Task.Delay(TimeSpan.FromSeconds(1), stoppingToken);
        }
    }
}

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        if (_executingTask == null)
        {
            return;
        }

        try
        {
            // Signal cancellation to the executing method
            _stoppingCts.Cancel();
        }
        finally
        {
            // Wait until the task completes or the stop token triggers
            await Task.WhenAny(_executingTask, Task.Delay(Timeout.Infinite, cancellationToken));
        }
    }

    protected abstract Task ExecuteAsync(CancellationToken cancellationToken);

    public virtual void Dispose() => _stoppingCts.Cancel();
}

public class GreeterUpdaterService : HostedService
{
    Greeter _greeter;
    public GreeterUpdaterService(Greeter greeter)
    {
        _greeter = greeter;
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            _greeter.Counter++;
            await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
        }
    }
}

public class Greeter
{
    public int Counter { get; set; }

    public override string ToString() => $"Hello world {Counter}";
}

