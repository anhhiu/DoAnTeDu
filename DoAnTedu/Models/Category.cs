using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoAnTedu.Models
{
    public class Category
    {
        [Key]
        public int ID { set; get; }

        [Required]
        [MaxLength(256)]
        public string? Name { set; get; }

        public DateTime CreatedAt { set; get; } = DateTime.Now;

        public bool? DeleteStatus { set; get; } = false;

        // Navigation property
        public virtual IEnumerable<Product> Products { set; get; } = Enumerable.Empty<Product>();
    }

}
