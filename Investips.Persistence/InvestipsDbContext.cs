using Investips.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Investips.Persistence
{
    public class InvestipsDbContext : DbContext
    {
        public DbSet<Portfolio> Porfolios { get; set; }
        public DbSet<Security> Securities { get; set; }
        public InvestipsDbContext(DbContextOptions<InvestipsDbContext> options)
            : base((DbContextOptions) options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBulder)
        {
            modelBulder.Entity<PortfolioSecurity>().HasKey(ps =>
                new { ps.PortfolioId, ps.SecurityId });
        }
    }
}
