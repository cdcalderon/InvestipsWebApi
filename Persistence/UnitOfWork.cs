using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Investips.Core;

namespace InvestipsApi.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InvestipsDbContext context;
        public UnitOfWork(InvestipsDbContext context)
        {
            this.context = context;

        }
        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
