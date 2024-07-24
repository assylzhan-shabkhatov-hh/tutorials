using Microsoft.Extensions.Hosting;
using Infrastructure.SqlServer.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.SqlServer;
using Microsoft.EntityFrameworkCore;
using MapsterApp;
using Mapster;
using MapsterMapper;
using System.Reflection;

IConfigurationRoot config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile("appsettings.local.json", optional: true)
    .Build();

var serviceProvider = new ServiceCollection()
        .AddAppDbContext(config, "Application")
        .BuildServiceProvider();

var db = serviceProvider.GetRequiredService<ApplicationDbContext>();
