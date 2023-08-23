using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace Cities.DB.Entities
{
    public class City
    {
        [Key]
        public long Id { get; set; }
        [MaxLength(50), Required]
        public string Name { get; set; }
        [MaxLength(50)]
        public string NameASCII { get; set; }
        public float Lat { get; set; }
        public float Lng { get; set; }
        public string AdminName { get; set; }
        public long Population { get; set; }
        public long CountryId { get; set; }
        public long CityTypeId { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }
        
        [ForeignKey("CityTypeId")]
        public virtual CityType CityType { get; set; }
    }
}