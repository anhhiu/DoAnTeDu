using Microsoft.AspNetCore.Identity;

namespace DoAnTedu.Data
{
    public class User : IdentityUser
    {
        public string? FullName { get; set; }
    }
}
