using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DoAnTedu.Models
{
    public class UpdatecrD1
    {
        //[Key]
        //public int ID { get; set; }
        //public int BPID { get; set; }
        public int? LocationId { get; set; } // id dia chi xa phuong
        public string? Type { get; set; } = "S"; // S- Địa chỉ giao hàng , B - Địa chỉ xuất hóa đơn
        public string? LocationName { get; set; } // dia chi xa, phuong
        public int? AreaId { get; set; }
        public string? AreaName { get; set; }// ten dia chi tp, huyen
        public string? Address { get; set; } // dia chi cu the
        [EmailAddress(ErrorMessage ="email khong dung dinh dang")]
        public string? Email { get; set; } //phamvantu.cs@gmail.com",
        [Phone(ErrorMessage ="so dien thoai khong hop le")]
        public string? Phone { get; set; } // "0986734453",
        public string? Person { get; set; } // Pham Van Tu
        public string? Default { get; set; } = "Y"; //Y - Địa chỉ mặc định, N-Không
        public string? Note { get; set; }
        public string? Status { get; set; } //D- Xóa, A- Thêm, U - Cập nhâp , Null - Không làm gì
    }

    public class UpdatecrD2
    {
        //[Key]
        //public int ID { get; set; }
        //public int BPID { get; set; }
        public string? Type { get; set; } // I hang hoa, T- loai san pham
        public int TypeId { get; set; } //id loai
        public string? TypeCode { get; set; }// ma loai
        public string? TypeName { get; set; }// ten loai
        public string? Status { get; set; } //  D: xoa, A: them, U: cap nhat, null: khong lam gi
    }

    public class UpdatecrD3
    {
    //    [Key]
    //    public int ID { get; set; }
    //    public int BPID { get; set; }
        public int PaymentMethodId { get; set; } // id loai
        public string? PaymentMethodCode { get; set; } // ma loai
        public string? PaymentMethodName { get; set; } // ten loai
        [Column(TypeName = ("decimal(18,2)"))]
        public decimal Balance { get; set; } // cong no hien tai
        [Column(TypeName = ("decimal(18,2)"))]
        public decimal BalanceLimit { get; set; } // han muc cong no
        public string? Status { get; set; } //  D: xoa, A: them, U: cap nhat, null: khong lam gi
    }

    public class UpdatecrD4
    {
        //public int ID { get; set; } // id dong
        //public int BPID { get; set; }  // Id cha
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

    public class UpdatecrD5
    {
        //[Key]
        //public int ID { get; set; } // ID dòng
        //public int BPID { get; set; } // ID cha
        [Phone(ErrorMessage ="sdt khong hop le")]
        public string? Phone1 { get; set; } // Số điện thoại
        [EmailAddress(ErrorMessage ="email khong hop le")]
        public string? Email { get; set; } // Email
        [Phone(ErrorMessage = "sdt khong hop le")]
        public string? Phone { get; set; } // Số điện thoại (thứ 2 hoặc trùng với Phone1)
        public string? Person { get; set; } // Người liên hệ
        public string? Default { get; set; } // Địa chỉ mặc định
        public string? Note { get; set; } // Ghi chú
        public string? Status { get; set; } // Trạng thái
    }

}
