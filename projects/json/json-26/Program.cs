using System.Text.Json.Nodes;
using System.Text.Json;

var app = WebApplication.Create();
app.Run(async context =>
{
    var objectNode = JsonNode.Parse("""
    {
        "name" : "abdelfattah",
        "age" : 33,
        "isMarried" : true,
        "gender" : "non-binary",
        "address" : {
            "city" : "Cairo",
            "country" : "Egypt"
        },
        "favoriteNumbers" : [3, 9, 10, 11] 
    }
    """);

    await context.Response.WriteAsync("From JsonNode.Parse\n");
    await context.Response.WriteAsync(objectNode.ToString());
    await context.Response.WriteAsync("\n\n");

    var json = objectNode.AsObject();

    foreach(var i in json)
    {
        var val = i.Value;
        switch(val.GetValueKind())
        {
            case JsonValueKind.String : 
                await context.Response.WriteAsync($"|{i.Key} |{val} | string |\n");
                break;
            case JsonValueKind.False:
            case JsonValueKind.True:
                await context.Response.WriteAsync($"|{i.Key} |{val} | boolean |\n");
                break;
            case JsonValueKind.Number:
                var v = val.AsValue();
                if (v.TryGetValue(out int intVal))
                {
                    await context.Response.WriteAsync($"|{i.Key} |{intVal} | int |\n");
                }
                else if (v.TryGetValue(out int doubleVal))
                {
                    await context.Response.WriteAsync($"|{i.Key} |{doubleVal} | double |\n");        
                }
                break;
            case JsonValueKind.Array:
                    var arr = val.AsArray();
                    await context.Response.WriteAsync($"|{i.Key} |{arr} | array |\n");
                break;
            case JsonValueKind.Object:
                    var obj = val.AsObject();
                    await context.Response.WriteAsync($"|{i.Key} |{obj} | object |\n");
                break;
            default : break;
        }
    }
});

app.Run();