using System.ComponentModel.DataAnnotations;

namespace DoAnTedu.Dtos.Acccounts
{
    public class Login
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
