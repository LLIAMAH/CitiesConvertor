using Cities.DB;
using Cities.DB.Entities;
using CitiesConvertor.Classes;
using CsvHelper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Globalization;
using System.IO;

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

var FilePath = "C:\\Users\\Squirrel\\Downloads\\simplemaps_worldcities_basicv1.76\\worldcities.csv";

//using (StreamReader reader = new StreamReader(FilePath))
//{
//    string? line;
//    while ((line = await reader.ReadLineAsync()) != null)
//    {
//        var split = line.Split(',');
//        if (split.Length != 11)
//        {
//            throw new Exception("Размер рабитой строки не валиден!");
//        }
        
//        var record = new RawDataItem()
//        {
//            city = split[0],
//            city_ascii = split[1],
//            lat = ConvertToDouble(split[2]),
//            lng = ConvertToDouble(split[3]),
//            country = split[4],
//            iso2 = split[5],
//            iso3 = split[6],
//            admin_name = split[7],
//            capital = split[8],
//            population = ConvertToInt(split[9]),
//            id = ConvertToLong(split[10])
//        };
//    }
//}
using (var reader = new StreamReader(FilePath))
using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
{
    csv.Context.RegisterClassMap<RawDataItemMap>();
    var records = csv.GetRecords<RawDataItem>();
    var countries = records.Select(o=>o.country).Distinct().ToList();
    var capitals = records.Select(o=>o.capital).Distinct().ToList();
    var t = records;
}






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

int ConvertToInt (string data)
{
    var converted = 0;
    int.TryParse(data, out converted);
    return converted;
}
double ConvertToDouble(string data)
{
    double converted = 0;
    double.TryParse(data, CultureInfo.InvariantCulture, out converted);
    return converted;
}
long ConvertToLong(string data)
{
    long converted = 0;
    long.TryParse(data, CultureInfo.InvariantCulture, out converted);
    return converted;
}