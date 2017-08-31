using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestipsApi.Core.Models
{
    public class PortfolioSecurity
    {
        public int PortfolioId { get; set; }
        public int SecurityId { get; set; }
        public Portfolio Portfolio { get; set; }
        public Security Security { get; set; }
    }
}
