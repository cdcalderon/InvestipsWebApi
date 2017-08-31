using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace InvestipsApi.Controllers.Resources
{
    public class PortfolioResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime LastUpdate { get; set; }
        public ICollection<SecurityResource> Securities { get; set; }
        public PortfolioResource()
        {
            Securities = new Collection<SecurityResource>();
        }
    }
}
