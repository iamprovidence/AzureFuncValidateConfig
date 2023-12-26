using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();

        services
            .AddScoped<MyService>();

        services
            .AddOptions<MyOptions>()
            .Validate(x => false)
            .ValidateOnStart();
    })
    .Build();

host.Run();

public class MyOptions
{
}

public class MyService
{
    private readonly IOptions<MyOptions> _options;

    public MyService(IOptions<MyOptions> options)
    {
        _options = options;
    }

    public void MyMethod()
    {
        Console.WriteLine("Hello World");
    }
}