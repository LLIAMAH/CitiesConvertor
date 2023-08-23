using Cities.DB;
using Cities.DB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(cfg => { cfg.AddJsonFile("appsettings.json"); })
    .ConfigureServices((context, services) =>
    {
        services.AddDbContext<AppDbCtx>(options =>
        {
            options.UseSqlServer(context.Configuration.GetConnectionString("DefaultConnection"));
        });
    })
    .ConfigureLogging((context, cfg) =>
    {
        cfg.ClearProviders();
        cfg.AddConfiguration(context.Configuration.GetSection("Logging"));
        cfg.AddConsole();
    })
    .Build();

using (var ctx = host.Services.GetService<AppDbCtx>())
{
    /*
    ctx.Tests.Add(new Country() { Data = "Test" });
    ctx.Tests.Add(new Country() { Data = "Test1" });
    ctx.Tests.Add(new Country() { Data = "Test2" });
    ctx.Tests.Add(new Country() { Data = "Test3" });
    ctx.Tests.Add(new Country() { Data = "Test4" });

    ctx.SaveChanges();
    */
}