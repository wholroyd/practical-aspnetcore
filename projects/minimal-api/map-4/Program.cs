using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference();

string Plaintext() => "Hello, World!";
app.MapGet("/hello", Plaintext);

Greeting Json() => new Greeting("Hello, World!");
app.MapGet("/json", Json);

app.MapGet("/hello/{name}", (string name) => new Greeting($"Hello, {name}!"));

app.Run();

public record Greeting(string Message);