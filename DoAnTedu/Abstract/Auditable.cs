using System.ComponentModel.DataAnnotations;

namespace DoAnTedu.Abstract
{
    public abstract class Auditable : IAuditable
    {
        public DateTime? CreatedDate { get; set; }
        [MaxLength(256)]
        public string CreateBy { get; set; } = string.Empty;
        public DateTime? UpdatedDate { get; set; }
        [MaxLength(256)]
        public string UpdateBy { get; set; } = string.Empty;
        public string MetaKeyword { get; set; } = string.Empty;
        public string MetaDescription { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
