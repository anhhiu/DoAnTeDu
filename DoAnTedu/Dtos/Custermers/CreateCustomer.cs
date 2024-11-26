using DoAnTedu.Models;
using System.ComponentModel.DataAnnotations;

namespace DoAnTedu.Dtos.Custermers
{
    public class CreateCustomer
    {
        [Key]
        public int ID { get; set; } // id
        public string? Series { get; set; } // series = null
        public string? CardCode { get; set; } // makh : kh00001
        public string? CardName { get; set; }// tenkh: "Công ty cổ phần công nghệ FOXAI",
        public string? FrgnName { get; set; } // ten khac kh : "Công ty cổ phần công nghệ FOXAI",
        public string? CardType { get; set; } // C
        public string? LicTradNum { get; set; } // "0986734453",
        public string? Avatar { get; set; } // null
        public string? Gender { get; set; } // null
        public DateTime DateOfBirth { get; set; } // ngay sinh
        public int? LocationId { get; set; } // id dia chi xa, phuong
        public string? LocationName { get; set; } // dia chi xa phuong
        public int? AreaId { get; set; } // id dchi tp, huyen
        public string? AreaName { get; set; }// ten dc tp, huyen
        public string? Address { get; set; }// dchi cu the
        public string? Email { get; set; }// "phamvantu.cs@gmail.com",
        public string? Phone { get; set; }//"0986734453",
        public string? Person { get; set; }// Pham Van Tu",
        public string? Note { get; set; }
        public string? Status { get; set; } // D
        public string? RStatus { get; set; } //D
        public string? Area { get; set; } // null
        public string? Brand { get; set; } // ds thuong hieu
        public string? ItemType { get; set; } //ds loai sp
        public string? Industry { get; set; } // ds nganh hang
        public string? Packing { get; set; } // ds quy cach dong goi
        public string? BPArea { get; set; } // ds khu vuc
        public bool? IsAllBPSize { get; set; }
        public string? BPSize { get; set; } // ds quy mo
        public virtual ICollection<crD1> CrD1s { get; set; } = new List<crD1>();
        public virtual ICollection<crD2> CrD2s { get; set; } = new List<crD2>();
        public virtual ICollection<crD3> CrD3s { get; set; } = new List<crD3>();
        public virtual ICollection<crD4> CrD4s { get; set; } = new List<crD4>();
        public virtual ICollection<crD5> CrD5s { get; set; } = new List<crD5>();
    }
}
