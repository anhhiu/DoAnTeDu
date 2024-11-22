using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoAnTedu.Models
{
    [Table("ApplicationRoleGroups")]
    public class ApplicationRoleGroup
    {
        [Key]
        [Column(Order = 1)]
        public int GroupId { set; get; }

        [Column(Order = 2)]
        [StringLength(128)]
        [Key]
        public string? RoleId { set; get; }

        [ForeignKey("RoleId")]
        public virtual ApplicationRole? ApplicationRole { set; get; }

        [ForeignKey("GroupId")]
        public virtual ApplicationGroup? ApplicationGroup { set; get; }
    }
}
