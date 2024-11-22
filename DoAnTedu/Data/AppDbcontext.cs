using Microsoft.EntityFrameworkCore;

namespace DoAnTedu.Data
{
    public class AppDbcontext : DbContext
    {
        public AppDbcontext(DbContextOptions options) : base(options)
        {
        }
    }
}
