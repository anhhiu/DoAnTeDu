﻿using DoAnTedu.Abstract;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoAnTedu.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string? Barcode { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public int CategoryID { get; set; }

        public string? Brand { get; set; }

        public string? Size { get; set; } // Hỗ trợ nhiều size: "39,40,41"

        public int Quantity { get; set; } // Số lượng tồn
        [Column(TypeName ="decimal(18,2)")]

        public decimal Price { get; set; } // Giá bán
        [Column(TypeName ="decimal(18,2)")]

        public decimal? PromotionPrice { get; set; } // Giá khuyến mại
        [Column(TypeName ="decimal(18,2)")]

        public decimal OriginalPrice { set; get; } // Giá gốc

        public string? Warranty { get; set; } = "6 tháng"; // Bảo hành

        public string? Description { get; set; } // Mô tả ngắn

        public string? Details { get; set; } // Chi tiết sản phẩm

        public DateTime CreatedAt { set; get; } = DateTime.Now;

        public DateTime UpdatedAt { set; get; } = DateTime.Now;

        public bool? DeleteStatus { set; get; } = false;

        // Navigation properties
        [ForeignKey(nameof(CategoryID))]
        public virtual Category? Category { get; set; }

        public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
    }
}
