using DoAnTedu.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoAnTedu.Dtos.Products
{
    public class CreateProduct
    {

        [Required]
        public string? Name { get; set; }

        [Required]
        public int CategoryID { get; set; }

        public string? Brand { get; set; }

        public string? Size { get; set; } // Hỗ trợ nhiều size: "39,40,41"

        public int Quantity { get; set; } // Số lượng tồn
        [Column(TypeName = "decimal(18,2)")]

        public decimal Price { get; set; } // Giá bán
        [Column(TypeName = "decimal(18,2)")]

        public decimal? PromotionPrice { get; set; } // Giá khuyến mại
        [Column(TypeName = "decimal(18,2)")]

        public decimal OriginalPrice { set; get; } // Giá gốc

        public string? Description { get; set; } // Mô tả ngắn

        public string? Details { get; set; } // Chi tiết sản phẩm

        public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
    }
}
