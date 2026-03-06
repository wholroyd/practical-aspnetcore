using Scalar.AspNetCore;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder();
builder.Services.AddOpenApi();
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.MapOpenApi();
app.MapScalarApiReference();
app.UseStaticFiles();
app.MapDefaultControllerRoute();
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
            Content = "<html><body><b><a href=\"/scalar\">View API Documentation</a></b></body></html>",
            ContentType = "text/html"
        };
    }
}

[Produces("application/json")]
[Route("api/[controller]")]
[ApiController]
[ApiExplorerSettings()]
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
    [Tags("Basic")]
    public ActionResult<Greeting> Index()
    {
        return new Greeting
        {
            Message = "Hello World"
        };
    }

    [HttpPost("goodbye")]
    [Tags("Basic")]
    public ActionResult<Greeting> Goodbye(string name)
    {
        return new Greeting
        {
            Message = "Goodbye",
            PersonName = name
        };
    }

    [HttpPut("")]
    [Tags("Intermediate")]
    public ActionResult<Greeting> Relay(Greeting greet)
    {
        return greet;
    }

    [HttpDelete("greetings/{name}")]
    [Tags("Intermediate")]
    public ActionResult Remove(string name)
    {
        return Ok($"{name} removed");
    }

    [HttpPatch("")]
    [Tags("Advanced")]
    public ActionResult<Greeting> Update(string city)
    {
        return new Greeting
        {
            Message = "Hello World",
            PersonAddressCity = city
        };
    }

    [HttpGet("hide/this")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public ActionResult HideThis()
    {
        return Ok(new { gretting = "hello" });
    }

    [HttpGet("hide/this2")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public ActionResult HideThisToo()
    {
        return Ok(new { gretting = "hello" });
    }

    [HttpGet("hide/fail")]
    public ActionResult NotHidden()
    {
        return Ok(new { gretting = "hello" });
    }
}
