using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvestipsApi.Core.Models;

namespace InvestipsApi.Core
{
    public interface IPortfolioRepository
    {
        Task<Portfolio> GetPortfolio(int id, bool includeProps = true);
        Task<List<Portfolio>> GetPortfolios();
        void Add(Portfolio porfolio);
        void Remove(Portfolio porfolio);
    }
}
