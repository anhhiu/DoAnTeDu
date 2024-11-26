using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DoAnTedu.Models
{
    public class crD1
    {
        [Key]
        public int ID { get; set; }
        public int BPID { get; set; }
        [JsonIgnore]
        [ForeignKey(nameof(BPID))]
        public virtual Customer? Customer { get; set; }
        public int? LocationId { get; set; } // id dia chi xa phuong
        public string? Type { get; set; } = "S"; // S- Địa chỉ giao hàng , B - Địa chỉ xuất hóa đơn
        public string? LocationName { get; set; } // dia chi xa, phuong
        public int? AreaId { get; set; }
        public string? AreaName { get; set; }// ten dia chi tp, huyen
        public string? Address { get; set; } // dia chi cu the
        public string? Email { get; set; } //phamvantu.cs@gmail.com",
        public string? Phone { get; set; } // "0986734453",
        public string? Person { get; set; } // Pham Van Tu
        public string? Default { get; set; } = "Y"; //Y - Địa chỉ mặc định, N-Không
        public string? Note { get; set; }
        public string? Status { get; set; } //D- Xóa, A- Thêm, U - Cập nhâp , Null - Không làm gì
    }
}
