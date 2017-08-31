﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvestipsApi.Core;
using InvestipsApi.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace InvestipsApi.Persistence
{
    public class SecurityRepository : ISecurityRepository
    {
        private readonly InvestipsDbContext context;

        public SecurityRepository(InvestipsDbContext context)
        {
            this.context = context;
        }
        public void Add(Security security)
        {
            context.Securities.Add(security);
        }

        public async Task<Security> GetSecurity(int id)
        {
            return await context.Securities.SingleOrDefaultAsync(s => s.Id == id);
        }
    }
}