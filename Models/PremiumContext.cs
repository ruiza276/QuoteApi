using Microsoft.EntityFrameworkCore;

namespace QuoteApi.Models
{
    public class PremiumContext : DbContext
    {
        public PremiumContext(DbContextOptions<PremiumContext> options)
            : base(options)
        {
        }

        public DbSet<PremiumItem> PremiumItems { get; set; }

        public DbSet<QuoteItem> QuoteItems { get; set; }
    }
}