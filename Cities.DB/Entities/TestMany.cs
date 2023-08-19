using System.ComponentModel.DataAnnotations;

namespace Cities.DB.Entities
{
    public class TestMany
    {
        [Key]
        public long Id { get; set; }

        public string Data { get; set; }

        public virtual ICollection<Test>? Tests { get; set; }
    }
}