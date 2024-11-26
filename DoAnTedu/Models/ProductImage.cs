using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoAnTedu.Models
{
    public class ProductImage
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int ProductID { get; set; }

        [Required]
        public string ImageUrl { get; set; } = string.Empty; // Đường dẫn ảnh

        [ForeignKey(nameof(ProductID))]
        public virtual Product? Product { get; set; }
    }

}
