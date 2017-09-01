using System.Collections.Generic;
using System.Threading.Tasks;
using Investips.Core;
using Investips.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Investips.Persistence
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly InvestipsDbContext context;
        public PortfolioRepository(InvestipsDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Portfolio>> GetPortfolios()
        {
            return await context.Porfolios
                .Include(p => p.Securities)
                .ThenInclude(ps => ps.Security)
                .ToListAsync();
        }
        public async Task<Portfolio> GetPortfolio(int id, bool includeProps = true)
        {
            if (!includeProps)
            {
                return await context.Porfolios.FindAsync(id);
            }
            return await context.Porfolios
                .Include(p => p.Securities)
                .ThenInclude(ps => ps.Security)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public void Add(Portfolio porfolio)
        {
            context.Porfolios.Add(porfolio);
        }

        public void Remove(Portfolio porfolio)
        {
            context.Remove(porfolio);
        }
    }
}
