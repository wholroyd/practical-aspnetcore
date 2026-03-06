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
            <li><a href="/about">/about</a></li>
            <li><a href="/about/us">/about/us</a></li>
            <li><a href="/about/all">/about/all</a></li>
            <li><a href="/transaction">/transaction</li>
            <li><a href="/transaction/pay">/transaction/pay</li>
            <li><a href="/scalar">Scalar API Documentation</a></li>
            <li><a href="/openapi/v1.json">OpenAPI JSON</a></li>
        </ul>
    </div>
</body>
</html>
""", "text/html")).ExcludeFromDescription();


app.MapGroup("/about")
    .MapAboutApi();

app.MapGroup("/transaction")
    .MapTransactionApi();

app.Run();

public static class AboutApi
{
    public static RouteGroupBuilder MapAboutApi(this RouteGroupBuilder group)
    {
        group.MapGet("/", () => Results.Ok("about")).ExcludeFromDescription();
        group.MapGet("/us", () => Results.Ok("Us"));
        group.MapGet("/all", () => Results.Ok("All"));

        return group;
    }
}

public static class TransactionAPI
{
    public static RouteGroupBuilder MapTransactionApi(this RouteGroupBuilder group)
    {
        group.MapGet("/", () => Results.Ok("transaction")).ExcludeFromDescription();
        group.MapGet("/pay", () => Results.Ok("Pay"));
        
        return group;
    }
}

