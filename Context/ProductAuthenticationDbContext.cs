using Microsoft.EntityFrameworkCore;

namespace ProductReviewAuthentication.Models
{
    public class ProductAuthenticationDbContext : DbContext
    {
        public ProductAuthenticationDbContext(DbContextOptions<ProductAuthenticationDbContext> options)
             : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Review> Reviews { get; set; }
    }
}
