using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DoAnTedu.Models
{
    [Table("Menus")]
    public class Menu
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }
        [Required]
        public string? URL { get; set; }
        public string? DisplayOrder { get; set; }
        [Required]
        public string? GroupID { get; set; }

        [ForeignKey(nameof(GroupID))]
        [JsonIgnore]
        public virtual MenuGroup? MenuGroup { get; set; }
        public string? Target { get; set; }
        [Required]
        public bool Status { get; set; }
    }
}
