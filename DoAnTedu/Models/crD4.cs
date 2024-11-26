using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DoAnTedu.Models
{
    public class crD4
    {
        public int ID { get; set; } // id dong
        public int BPID { get; set; }  // Id cha
        [JsonIgnore]
        [ForeignKey(nameof(BPID))]
        public virtual Customer? Customer { get; set; }
        public string? InvoiceNumber { get; set; } // Số hóa đơn
        public DateTime InvoiceDate { get; set; } // Ngày hóa đơn
        public DateTime DueDate { get; set; } // Ngày đến hạn
        [Column(TypeName = ("decimal(18,2)"))]
        public decimal DaysOverdue { get; set; } // Số ngày quá hạn
        [Column(TypeName = ("decimal(18,2)"))]
        public decimal InvoiceTotal { get; set; } // Tổng công nợ
        [Column(TypeName = ("decimal(18,2)"))]
        public decimal PaidAmount { get; set; } // Tiền đã thanh toán
        [Column(TypeName = ("decimal(18,2)"))]
        public decimal AmountOverdue { get; set; } // Số tiền quá hạn
        public string? Status { get; set; } // D: xoa, A: them, U: cap nhat, null: khong lam gi
    }
}
