using Elsa.Extensions;
using Elsa.Workflows;
using Elsa.Workflows.Activities;
using Elsa.Workflows.Memory;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddElsa();

var app = builder.Build();

// Use the service provider from the host
var runner = app.Services.GetRequiredService<IWorkflowRunner>();
await runner.RunAsync(new ConstructorWorkflow("Anne", 37));

public class ConstructorWorkflow : WorkflowBase
{
    private readonly Variable<string> _name;
    private readonly Variable<int> _age;

    public ConstructorWorkflow(string name, int age)
    {
        _name = new Variable<string>("name", name);
        _age = new Variable<int>("age", age);
    }

    protected override void Build(IWorkflowBuilder builder)
    {
        builder.Root = new Sequence
        {
            Variables = { _name, _age },
            Activities = 
            {
                new WriteLine(ctx => $"Name: {_name.Get(ctx)}"),
                new WriteLine(ctx => $"Age: {_age.Get(ctx)}")
            }
        };
    }
}
