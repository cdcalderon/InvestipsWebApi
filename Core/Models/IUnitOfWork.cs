using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestipsApi.Core.Models
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
