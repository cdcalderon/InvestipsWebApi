using System.Threading.Tasks;
using Investips.Core;

namespace Investips.Persistence
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
