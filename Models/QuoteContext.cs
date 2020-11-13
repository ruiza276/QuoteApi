using Microsoft.EntityFrameworkCore;
using QuoteApi.Models;

namespace QuoteApi.Models
{
    public class QuoteContext : DbContext
    {
        public QuoteContext(DbContextOptions<QuoteContext> options)
            : base(options)
        {
        }

        public DbSet<QuoteItem> QuoteItems { get; set; }
    }
}