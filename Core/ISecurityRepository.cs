using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvestipsApi.Core.Models;

namespace InvestipsApi.Core
{
    public interface ISecurityRepository
    {
        Task<Security> GetSecurity(int id);
        void Add(Security security);
    }
}
