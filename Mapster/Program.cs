using Microsoft.Extensions.Hosting;
using Infrastructure.SqlServer.Extensions;
using Microsoft.Extensions.Configuration;

namespace Mapster
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

            IConfigurationRoot config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile("appsettings.local.json", optional: true)
                .Build();

            builder.Services.AddAppDbContext(config, "App");


            using IHost host = builder.Build();

            await host.RunAsync();
        }
    }
}
