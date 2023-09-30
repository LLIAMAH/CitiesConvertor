using CitiesConvertor.Classes;
using CsvHelper.Configuration;

namespace CitiesConvertor.Classes
{
    /*
    public struct AAAAStruct // VALUABLE - значимый
    {
        public string Param { get; set; }

        public string Param1 { get; set; }
        public string Param2 { get; set; }

        public static bool operator ==(AAAAStruct input1, AAAAStruct input2)
        {
            return input1.Param.Equals(input2.Param);
        }
        public static bool operator !=(AAAAStruct input1, AAAAStruct input2)
        {
            return !input1.Param.Equals(input2.Param);
        }
    }*/

    public class RawDataItem // REFERENCED - внутри ссылка
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

        public override string ToString()
        {
            return $"{city}:{country}:{capital}";
        }

        public override bool Equals(object? obj)
        {
            if(obj == null) return false;
            var converted = obj as RawDataItem;
            if (converted == null) return false;

            return this.city.Equals(converted.city) // false
                   && this.country.Equals(converted.country) // true
                   && this.capital.Equals(converted.capital); // true;
        }

        public override int GetHashCode()
        {
            return this.city.GetHashCode() ^ this.country.GetHashCode();
        }
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