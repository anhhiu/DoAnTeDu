using System.ComponentModel.DataAnnotations;

namespace DoAnTedu.Dtos.Acccounts
{
    public class Register
    {
        public string? FullName { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Phone]
        public string? Phone {  get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string?  ConfilmPassword { get; set; }
        [Required]
        public string? Role { get; set; }
    }
}
