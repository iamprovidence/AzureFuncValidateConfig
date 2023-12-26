using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(FunctionAppNet6.Startup))]

namespace FunctionAppNet6
{
    public class MyOptions
    {
    }

    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var services = builder.Services;

            services
                .AddOptions<MyOptions>()
                .Validate(x => false)
                .ValidateOnStart();
        }
    }
}