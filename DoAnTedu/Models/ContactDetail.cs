using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoAnTedu.Models
{
    [Table("ContactDetails")]
    public class ContactDetail
    {
        [Key]
        public int ID { set; get; }

        [StringLength(250)]
        [Required]
        public string? Name { set; get; }

        [StringLength(50)]
        public string? Phone { set; get; }

        [StringLength(250)]
        public string? Email { set; get; }

        [StringLength(250)]
        public string? Website { set; get; }

        [StringLength(250)]
        public string? Address { set; get; }

        public string? Other { set; get; }

        public double? Lat { set; get; }

        public double? Lng { set; get; }

        public bool Status { set; get; }
    }
}
