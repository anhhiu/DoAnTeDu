using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoAnTedu.Models
{
    [Table("ApplicationGroups")]
    public class ApplicationGroup
    {
        [Key]
        
        public int ID { set; get; }

        [StringLength(250)]
        public string? Name { set; get; }

        [StringLength(250)]
        public string? Description { set; get; }
    }
}
