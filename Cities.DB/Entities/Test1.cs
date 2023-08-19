using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cities.DB.Entities
{
    public class Test1
    {
        [Key]
        public long Id { get; set; }

        public string TestData { get; set; }
    }
}