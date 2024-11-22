using DoAnTedu.Abstract;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoAnTedu.Models
{
    [Table("Pages")]
    public class Page : Auditable
    {
        [Key]
        public int ID { set; get; }

        [Required]
        [MaxLength(256)]
        public string? Name { set; get; }

        [Column(TypeName = "varchar")]
        [MaxLength(256)]
        [Required]
        public string? Alias { set; get; }

        public string? Content { set; get; }
    }
}
