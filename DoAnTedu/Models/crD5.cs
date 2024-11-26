using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DoAnTedu.Models
{
    public class crD5
    {
        [Key]
        public int ID { get; set; } // ID dòng
        public int BPID { get; set; } // ID cha
        [JsonIgnore]
        [ForeignKey(nameof(BPID))]
        public virtual Customer? Customer { get; set; }
        public string? Phone1 { get; set; } // Số điện thoại
        public string? Email { get; set; } // Email
        public string? Phone { get; set; } // Số điện thoại (thứ 2 hoặc trùng với Phone1)
        public string? Person { get; set; } // Người liên hệ
        public string? Default { get; set; } // Địa chỉ mặc định
        public string? Note { get; set; } // Ghi chú
        public string? Status { get; set; } // Trạng thái
    }
}
