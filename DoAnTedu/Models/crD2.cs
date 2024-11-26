using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DoAnTedu.Models
{
    public class crD2
    {
        [Key]
        public int ID { get; set; }
        public int BPID { get; set; }
        [JsonIgnore]
        [ForeignKey(nameof(BPID))]
        public virtual Customer? Customer { get; set; }
        public string? Type { get; set; } // I hang hoa, T- loai san pham
        public int TypeId { get; set; } //id loai
        public string? TypeCode { get; set; }// ma loai
        public string? TypeName { get; set; }// ten loai
        public string? Status { get; set; } //  D: xoa, A: them, U: cap nhat, null: khong lam gi
    }
}
