using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DoAnTedu.Models
{
    // cong no
    public class crD3 
    {
        [Key]
        public int ID { get; set; }
        public int BPID { get; set; }
        [JsonIgnore]
        [ForeignKey(nameof(BPID))]
        public virtual Customer? Customer { get; set; }
        public int PaymentMethodId { get; set; } // id loai
        public string? PaymentMethodCode { get; set; } // ma loai
        public string? PaymentMethodName { get; set; } // ten loai
        [Column(TypeName =("decimal(18,2)"))]
        public decimal Balance { get; set; } // cong no hien tai
        [Column(TypeName = ("decimal(18,2)"))]
        public decimal BalanceLimit { get; set; } // han muc cong no
        public string? Status { get; set; } //  D: xoa, A: them, U: cap nhat, null: khong lam gi
    }
}
