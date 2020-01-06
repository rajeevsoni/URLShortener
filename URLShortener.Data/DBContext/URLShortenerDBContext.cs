using Microsoft.EntityFrameworkCore;
using URLShortener.Data.Entities;

namespace URLShortener.Data.DBContext
{
    public class URLShortenerDBContext : DbContext
    {
       public URLShortenerDBContext (DbContextOptions<URLShortenerDBContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<URLInfo>()
                .HasIndex(x => x.HashedURL).IsUnique();
        }

        public DbSet<URLInfo> URLInfos { get; set; }

    }
}
