using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnTedu.Models
{
    [Table("MenuGroups")]
    public class MenuGroup
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string? Name { get; set; }

        public virtual IEnumerable<Menu> Menu { get; set; } = Enumerable.Empty<Menu>();
    }
}
