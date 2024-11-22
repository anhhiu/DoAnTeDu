namespace DoAnTedu.Abstract
{
    public interface IAuditable
    {
        DateTime? CreatedDate { get; set; }
        string CreateBy { get; set; }
        DateTime? UpdatedDate { get; set; }
        string UpdateBy { get; set; }
        string MetaKeyword { get; set; }
        string MetaDescription { get; set; }
        string Status { get; set; }
    }
}
