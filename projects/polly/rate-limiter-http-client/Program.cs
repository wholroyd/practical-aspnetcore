using System.Net;
using Polly;
using Polly.RateLimiting;
using Polly.Retry;

var builder = WebApplication.CreateBuilder();
builder.Logging.SetMinimumLevel(LogLevel.Warning);
builder.Logging.AddConsole();

var services = builder.Services;

services.AddRazorPages();

services.AddHttpClient("concurrency-http")
.ConfigureHttpClient((sp, client) =>
{
    client.Timeout = TimeSpan.FromSeconds(10);
}).AddResilienceHandler("concurrency-http-policy", (builder, c) =>
{
    builder
        .AddConcurrencyLimiter(permitLimit: 5, queueLimit: 5)// only allow 20 concurrent requests, queue up to 50
        .AddRetry(new RetryStrategyOptions<HttpResponseMessage>
        {
            ShouldHandle = response =>
            {
                if (response.Outcome.Exception is RateLimiterRejectedException)
                    return ValueTask.FromResult(true);

                // retry when the status is not OK
                var result = response.Outcome.Result.StatusCode != HttpStatusCode.OK;
                return ValueTask.FromResult(result);
            },
            MaxRetryAttempts = 3,
            DelayGenerator = static args =>
            {
                // Make the delay increase with each retry
                var delay = args.AttemptNumber switch 
                {
                    0 => TimeSpan.Zero,
                    1 => TimeSpan.FromSeconds(1),
                    _ => TimeSpan.FromSeconds(5)
                };

                // This example uses a synchronous delay generator,
                // but the API also supports asynchronous implementations.
                return new ValueTask<TimeSpan?>(delay);
            },
            OnRetry = args =>
            {
                var logger = c.ServiceProvider.GetService<ILogger<Program>>();
                logger.LogError("OnRetry, Attempt: {0}", args.AttemptNumber);

                // Event handlers can be asynchronous; here, we return an empty ValueTask.
                return default;
            },
            BackoffType = DelayBackoffType.Constant
        })
        .Build();
});

var app = builder.Build();
app.MapRazorPages();
app.Run();