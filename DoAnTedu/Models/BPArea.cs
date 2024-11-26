using System.ComponentModel.DataAnnotations;

namespace DoAnTedu.Models
{
    public class BPArea
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public int ParentId { get; set; }
    }
}
