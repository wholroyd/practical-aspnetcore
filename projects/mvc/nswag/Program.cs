using Scalar.AspNetCore;

using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();

var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();


[Route("")]
[ApiExplorerSettings(IgnoreApi = true)]
public class HomeController : ControllerBase
{
    [HttpGet("")]
    public ActionResult Index()
    {
        return new ContentResult
        {
            Content = "<html><body><b><a href=\"/swagger\">View API Documentation</a></b></body></html>",
            ContentType = "text/html"
        };
    }
}

[Produces("application/json")]
[Route("api/[controller]")]
[ApiController]
public class GreetingController : ControllerBase
{
    public class Greeting
    {
        public string Message { get; set; }

        public string PersonName { get; set; }

        public string PersonAddressCity { get; set; }
    }

    /// <summary>
    /// This is an API to return a "Hello World" message (this text comes from the Action comment)
    /// </summary>
    /// <response code="200">The "Hello World" text</response>
    [HttpGet("")]
    public ActionResult<Greeting> Index()
    {
        return new Greeting
        {
            Message = "Hello World"
        };
    }

    [HttpPost("goodbye")]
    public ActionResult<Greeting> Goodbye(string name)
    {
        return new Greeting
        {
            Message = "Goodbye",
            PersonName = name
        };
    }

    [HttpPut("")]
    public ActionResult<Greeting> Relay(Greeting greet)
    {
        return greet;
    }

    [HttpDelete("greetings/{name}")]
    public ActionResult Remove(string name)
    {
        return Ok($"{name} removed");
    }

    [HttpPatch("")]
    public ActionResult<Greeting> Update(string city)
    {
        return new Greeting
        {
            Message = "Hello World",
            PersonAddressCity = city
        };
    }
}
