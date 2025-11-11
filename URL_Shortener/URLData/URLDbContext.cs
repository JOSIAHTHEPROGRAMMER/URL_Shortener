using Microsoft.EntityFrameworkCore;
using URL_Shortener.Models;

namespace URL_Shortener.URLData

{
    public class  URLDbContext(DbContextOptions<URLDbContext> options) : DbContext(options)
    {
        public DbSet<URLMapping> Mapping => Set<URLMapping>();
    }
}
