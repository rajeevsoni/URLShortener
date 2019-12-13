using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Reflection;

namespace URLShortener.Data.DBContext
{
    public class URLShortenerDBContextFactory : IDesignTimeDbContextFactory<URLShortenerDBContext>
    {
        public URLShortenerDBContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config.GetConnectionString("URLShortenerDatabase");
            var builder = new DbContextOptionsBuilder<URLShortenerDBContext>();
            builder.UseSqlServer(connectionString,
                optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(URLShortenerDBContextFactory).GetTypeInfo().Assembly.GetName().Name));

            return new URLShortenerDBContext(builder.Options);
        }
    }
}
