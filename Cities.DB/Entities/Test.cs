using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cities.DB.Entities
{
    public class Test
    {
        [Key]
        public long Id { get; set; }

        public string Data { get; set; }

        [ForeignKey("Test1")]
        public long? Test1Id { get; set; }
        public virtual Test1? Test1 { get; set; }
    }
}
