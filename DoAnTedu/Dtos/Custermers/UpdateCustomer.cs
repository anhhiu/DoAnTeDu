using DoAnTedu.Models;
using System.ComponentModel.DataAnnotations;

namespace DoAnTedu.Dtos.Custermers
{

    public class UpdateCustomer
    {
        [Required(ErrorMessage = "phai nhap")]
        public string? CardName { get; set; }
        [Required(ErrorMessage = "phai nhap")]
        public string? FrgnName { get; set; }
        public string? CardType { get; set; }
        public string? LicTradNum { get; set; }
        public string? Avatar { get; set; }
        public string? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? LocationId { get; set; }
        public string? Address { get; set; }
        [EmailAddress(ErrorMessage = "email khong hop le")]
        public string? Email { get; set; }
        [Phone(ErrorMessage = "so dien thoai khobg hop le")]
        public string? Phone { get; set; }
        public string? Status { get; set; }
        public string? Note { get; set; }
    }
    public class UpdateCustomerMapper
    {
        [Required(ErrorMessage ="phai nhap")]
        public string? CardName { get; set; }
        [Required(ErrorMessage = "phai nhap")]
        public string? FrgnName { get; set; }
        public string? CardType { get; set; }
        public string? LicTradNum { get; set; }
        public string? Avatar { get; set; }
        public string? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? LocationId { get; set; }
        public string? Address { get; set; }
        [EmailAddress(ErrorMessage ="email khong hop le")]
        public string? Email { get; set; }
        [Phone(ErrorMessage ="so dien thoai khobg hop le")]
        public string? Phone { get; set; }
        public string? Status { get; set; }
        public string? Note { get; set; }

        public virtual ICollection<UpdatecrD1> CrD1s { get; set; } = new List<UpdatecrD1>();
        public virtual ICollection<UpdatecrD2> CrD2s { get; set; } = new List<UpdatecrD2>();
        public virtual ICollection<UpdatecrD3> CrD3s { get; set; } = new List<UpdatecrD3>();
        public virtual ICollection<UpdatecrD4> CrD4s { get; set; } = new List<UpdatecrD4>();
        public virtual ICollection<UpdatecrD5> CrD5s { get; set; } = new List<UpdatecrD5>();
    }
}
