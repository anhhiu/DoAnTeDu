using DoAnTedu.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace DoAnTedu.Models
{
    [Table("Products")]
    public class Product : Auditable
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Alias { get; set; }
        [Required]
        public int CategoryID { get; set; }

        public string? Image { get; set; }
        [Column(TypeName ="xml")]
        public string? MoreImage { get; set; }
        public decimal Price { get; set; }
        public decimal? PromotionPrice { get; set; }
        public int? Warranty { get; set; }

        public string? Description { get; set; }
        public string? Context {  get; set; }

        public bool? HomeFlag { get; set; }
        public bool? HotFlag { get; set; }
        public int? ViewCount { get; set; }

        public string? Tags { get; set; }
        public int Quantity { get; set; }
        public decimal OriginalPrice { set; get; }

        [ForeignKey(nameof(CategoryID))]
        public ProductCategory? ProductCategory { get; set; }
        public virtual IEnumerable<ProductTag>? ProductTags { set; get; } = Enumerable.Empty<ProductTag>();

    }
}
