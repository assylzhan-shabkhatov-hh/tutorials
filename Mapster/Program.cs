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

var person1 = new Person("Alice", 30);

var person2 = new Person("Bob", 25);



var personDict = new Dictionary<Person, string>
{

  { person1, "Some information about Alice" },

  { person2, "Some information about Bob" }

};
var searchPerson = new Person("Alice", 30);
Console.WriteLine(personDict.ContainsKey(searchPerson));