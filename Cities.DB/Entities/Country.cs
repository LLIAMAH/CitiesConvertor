using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cities.DB.Entities
{
    
    public class Country
    {
        [Key]
        public long Id { get; set; }
        
        [MaxLength(50), Required] 
        public string Name { get; set; }
        
        [MaxLength(2)]
        public string ISO2 { get; set; }
        
        [MaxLength(3)]
        public string ISO3 { get; set; }

    }
}
