using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder();

builder.Services.AddValidation();
builder.Services.AddAntiforgery();

var app = builder.Build();

app.MapGet("/", (IAntiforgery token, HttpContext context) =>
{
    var html = $"""
    <html>
    <head>
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <meta name="color-scheme" content="light dark">
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/@picocss/pico@2/css/pico.min.css">
    </head>
    <body>
        <main class="container">
        <h1>Server side validation</h1>
        <p>This is just a demo that show how built-in validation works in [FromForm] scenario but it can't really be used
        in a straight HTML serving scenario because right now there is no way to obtain the validation results.</p>
        <form method="post" action="/validate">
            <input type="hidden" name="__RequestVerificationToken" value="{token.GetAndStoreTokens(context).RequestToken}" />
            <fieldset>
                <legend>Person Information</legend>
                
                <label for="name">Name:</label>
                <input type="text" id="name" name="name" placeholder="Enter your name">
                <small>Name must be between 2 and 50 characters</small>
                
                <label for="email">Email:</label>
                <input type="email" id="email" name="email" placeholder="Enter your email">
                <small>Must be a valid email address</small>
                
                <label for="age">Age:</label>
                <input type="number" id="age" name="age" placeholder="Enter your age">
                <small>Age must be between 18 and 120</small>
                
                <button type="submit">Submit</button>
            </fieldset>
        </form>
        </main>
    </body>
    </html>
    """;

    return TypedResults.Content(html, "text/html");
}); 

app.MapPost("/validate", async ([FromForm]PersonInput input, IAntiforgery antiforgery, HttpContext context) =>
{
    await antiforgery.ValidateRequestAsync(context);

    return TypedResults.Ok(new
    {
        Message = "Validation successful!",
        Data = input
    });
});

app.UseAntiforgery();
app.Run();

public class PersonInput 
{
    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    [Range(18, 120)]
    public int? Age { get; set; }
}