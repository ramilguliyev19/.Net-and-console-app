using Microsoft.EntityFrameworkCore;
using pustokbackend.Models;

namespace pustokbackend
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<SecondPromotion>SecondPromotions { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
