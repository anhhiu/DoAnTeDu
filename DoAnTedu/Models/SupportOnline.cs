using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoAnTedu.Models
{
    [Table("SupportOnlines")]
    public class SupportOnline
    {
        [Key]
        public int ID { set; get; }

        [Required]
        [MaxLength(50)]
        public string? Name { set; get; }

        [MaxLength(50)]
        public string? Department { set; get; }

        [MaxLength(50)]
        public string? Skype { set; get; }

        [Phone]
        public string? Mobile { set; get; }

        [EmailAddress]
        public string? Email { set; get; }

        [MaxLength(50)]
        public string? Yahoo { set; get; }

        [MaxLength(50)]
        public string? Facebook { set; get; }

        public bool Status { set; get; }

        public int? DisplayOrder { set; get; }
    }
}
