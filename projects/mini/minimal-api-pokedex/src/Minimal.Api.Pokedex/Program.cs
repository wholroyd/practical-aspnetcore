using Minimal.Api.Pokedex;
using Minimal.Api.Pokedex.Extensions;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddPokedexApi();
var app = builder.Build();

app.UseStaticFiles();
app.MapOpenApi();
app.MapScalarApiReference();
app.MapPokedexApiRoutes();

app.Run();
