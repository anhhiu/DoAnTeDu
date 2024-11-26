using System.ComponentModel.DataAnnotations;

namespace DoAnTedu.Models
{
    public class BPSize
    {
        [Key]
        [Required]
        public int ID { get; set; }
        [Required]
        public string? Name { get; set; }
    }
}
