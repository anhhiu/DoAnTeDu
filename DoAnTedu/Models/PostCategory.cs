using DoAnTedu.Abstract;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoAnTedu.Models
{
    [Table("PostCategories")]
    public class PostCategory : Auditable
    {
        [Key]
        public int ID { set; get; }

        [Required]
        [MaxLength(256)]
        public string? Name { set; get; }

        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(256)]
        public string? Alias { set; get; }

        [MaxLength(500)]
        public string? Description { set; get; }

        public int? ParentID { set; get; }
        public int? DisplayOrder { set; get; }

        [MaxLength(256)]
        public string? Image { set; get; }

        public bool? HomeFlag { set; get; }

        public virtual IEnumerable<Post>? Posts { set; get; } = Enumerable.Empty<Post>();
    }
}
