using Microsoft.Extensions.Hosting;
using Infrastructure.SqlServer.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.SqlServer;
using Microsoft.EntityFrameworkCore;

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

            builder.Services.AddAppDbContext(config, "Application");

            using IHost host = builder.Build();

            using var serviceScope = host.Services.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;
            var db = provider.GetRequiredService<ApplicationDbContext>();

            var users = await db.Users.AsNoTracking()
                .ToListAsync(CancellationToken.None);

            await host.RunAsync();
        }
    }
}
