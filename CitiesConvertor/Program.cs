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
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

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

//var FilePath = "C:\\Users\\Squirrel\\Downloads\\simplemaps_worldcities_basicv1.76\\worldcities.csv";

var FilePath = "C:\\Users\\Squirrel\\simplemaps_worldcities_basicv1.76\\worldcities.csv";
//bool fileExist = File.Exists(FilePath);
/*
while (!File.Exists(FilePath) || FilePath == "Exit" )//fileExist)
{
    Console.WriteLine("File does not exist. Please, indicate the correct path. Enter 'Exit' to close process");
    FilePath = Console.ReadLine();
    
}
*/

/*using (StreamReader reader = new StreamReader(FilePath))
{
    string? line;
    while ((line = await reader.ReadLineAsync()) != null)
    {
        var split = line.Split(',');
        if (split.Length != 11)
        {
            throw new Exception("Размер рабитой строки не валиден!");
        }

        var record = new RawDataItem()
        {
            city = split[0],
            city_ascii = split[1],
            lat = ConvertToDouble(split[2]),
            lng = ConvertToDouble(split[3]),
            country = split[4],
            iso2 = split[5],
            iso3 = split[6],
            admin_name = split[7],
            capital = split[8],
            population = ConvertToInt(split[9]),
            id = ConvertToLong(split[10])
        };
    }
}
*/

using (var reader = new StreamReader(FilePath))
using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
{
    csv.Context.RegisterClassMap<RawDataItemMap>();
    var records = csv.GetRecords<RawDataItem>().ToList();
    var countries = records.Select(o => new Country
    {
        Name = o.country,
        ISO2 = o.iso2,
        ISO3 = o.iso3
    }).Distinct().ToList();
    var capitals = records.Select(o => new CityType
    {
        Name = o.capital
    }).Distinct().ToList();

    using (var ctx = host.Services.GetService<AppDbCtx>())
    {
        var bdcountries = ctx.Countries
            .ToDictionary(k => k.Name, v => v.Id);
        var bdcitytypes = ctx.CityTypes
            .ToDictionary(k => k.Name, v => v.Id);
        var missingcountries = GetMissingStCountries(bdcountries, countries);
        var missingcitytypes = GetMissingStCapitals(bdcitytypes, capitals);

        foreach (var country in countries)  
        {            
            ctx.Countries.Add( new Country() {Name =  country.Name, ISO2 = country.ISO2, ISO3 = country.ISO3} );
        }
        await ctx.SaveChangesAsync();

        foreach (var capital in capitals)
        {
            ctx.CityTypes.Add(new CityType() 
            { Name = capital.Name });
        }
        await ctx.SaveChangesAsync();

        //var bdcountries = ctx.Countries.ToList();
        //var bdcitytypes = ctx.CityTypes.ToList();
        
        foreach (var record  in records)
        {
            ctx.Cities.Add(new City()
            {
                Name = record.city,
                NameASCII = record.city_ascii,
                Lat = ConvertToFloat(record.lat),
                Lng = ConvertToFloat(record.lng),
                AdminName = record.admin_name,
                Population = ConvertToLong(record.population),
                CountryId = bdcountries[record.country], //First (o => o.Name == record.country).Id, //ctx.Countries.First(o=>o.Name==record.country).Id,
                CityTypeId = bdcitytypes[record.capital]//First(o=> o.Name == record.capital).Id //ctx.CityTypes.First(o=>o.Name == record.capital).Id
            });
        }
        await ctx.SaveChangesAsync();
    }
    var t = records;
}

List<CityType> GetMissingStCapitals(Dictionary<string, long> bdcitytypes, List<CityType> capitals)
{
    var exceptData = capitals.Select(o => o.Name)
      .Except(bdcitytypes.Select(o => o.Key));

    var dictionaryCapitals = capitals.ToDictionary(k => k.Name, v => v);

    var result = new List<CityType>();
    foreach (var capitalName in exceptData)
        result.Add(dictionaryCapitals[capitalName]);

    return result;
}

List<Country> GetMissingStCountries(Dictionary<string, long> bdcountries, List<Country> countries)
{
    var exceptData = countries.Select(o => o.Name)
        .Except(bdcountries.Select(o => o.Key));

    var dictionaryCountries = countries.ToDictionary(k => k.Name, v => v);

    var result = new List<Country>();
    foreach (var countryName in exceptData)
        result.Add(dictionaryCountries[countryName]);

    ///return exceptData.Select(countryName => dictionaryCountries[countryName]).ToList();

    return result;
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
float ConvertToFloat(string data)
{
    float converted = 0;
    float.TryParse(data, CultureInfo.InvariantCulture, out converted);
    return converted;
}
long ConvertToLong(string data)
{
    long converted = 0;
    long.TryParse(data, CultureInfo.InvariantCulture, out converted);
    return converted;
}
