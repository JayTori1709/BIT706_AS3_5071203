using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Registry.Data;


var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        var connStr = "server=localhost;database=RegistryDB;user=root;password=l3nardw12";
        services.AddDbContext<RegistryDbContext>(options =>
            options.UseMySql(connStr, ServerVersion.AutoDetect(connStr)));
    })
    .Build();

Console.WriteLine("✅ Data layer configured. You can now create migrations and seed the database.");
