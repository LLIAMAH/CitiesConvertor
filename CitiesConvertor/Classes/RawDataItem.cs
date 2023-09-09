using Cities.DB.Entities;
using CitiesConvertor.Classes;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiesConvertor.Classes
{
    public class RawDataItem
    {
        public string city { get; set; }
        public string city_ascii { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
        public string country { get; set; }
        public string iso2 { get; set; }
        public string iso3 { get; set; }
        public string admin_name { get; set; }
        public string capital { get; set; }
        public string population { get; set; }
        public string id { get; set; }

    }

}
public class RawDataItemMap : ClassMap<RawDataItem>
{
    public RawDataItemMap()
    {
        Map(p => p.city).Index(0);
        Map(p => p.city_ascii).Index(1);
        Map(p => p.lat).Index(2);
        Map(p => p.lng).Index(3);
        Map(p => p.country).Index(4);
        Map(p => p.iso2).Index(5);
        Map(p => p.iso3).Index(6);
        Map(p => p.admin_name).Index(7);
        Map(p => p.capital).Index(8);
        Map(p => p.population).Index(9);
        Map(p => p.id).Index(10);
    }
}