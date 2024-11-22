using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoAnTedu.Models
{
    [Table("Errors")]
    public class Error
    {
        [Key]
        public int ID { set; get; }

        public string? Message { set; get; }

        public string? StackTrace { set; get; }

        public DateTime CreatedDate { set; get; }
    }
}
