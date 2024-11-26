using DoAnTedu.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DoAnTedu.Data
{
    public class AppDbcontext : IdentityDbContext<User>
    {
        public AppDbcontext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<crD1> CrD1s { get; set; }
        public DbSet<crD2> CrD2s { get; set; }
        public DbSet<crD3> CrD3s { get; set; }
        public DbSet<crD4> CrD4s { get; set; }
        public DbSet<crD5> CrD5s { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<BPArea> BPAreas { get; set; }
        public DbSet<BPSize> BPSizes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
