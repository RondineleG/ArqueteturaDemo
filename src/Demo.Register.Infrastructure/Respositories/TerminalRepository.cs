﻿using Microsoft.EntityFrameworkCore;
using Proton.Register.Domain.Enums;
using Proton.Register.Domain.Interfaces.Repositories;
using Proton.Register.Domain.Models;
using Proton.Register.Domain.Queries;
using Proton.Register.Infrastructure.Base;
using Proton.Register.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Proton.Register.Infrastructure.Repositories
{
    public class TerminalRepository : RepositoryCrud<Terminal>, ITerminalRepository
    {

        private new readonly RegisterDataContext _context;

        public TerminalRepository(RegisterDataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Terminal>> Search(string name, EStatus? status)
        {

            IQueryable<Terminal> query = _context.Terminals;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(x => x.NameTerminal.Contains(name));
            }

            if (status != null)
            {
                query = query.Where(e => e.Status == status);
            }
            return await _context.Terminals.AsNoTracking().ToArrayAsync();
        }

        public async Task<IEnumerable<Terminal>> GetAllDeleted()
        {
            return await _context.Terminals.IgnoreQueryFilters().AsNoTracking().Where(x => x.IsDeleted == true).ToListAsync();
        }

        public IEnumerable<Terminal> FindByName(string name)
        {
            return _context.Terminals.Where(p => p.NameTerminal == name);
        }

        public IQueryable<Terminal> List(Expression<Func<Terminal, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<QueryResult<Terminal>> ListAsync(TerminalsQuery query)
        {
            IQueryable<Terminal> queryable = _context.Terminals
                                                    .Include(x => x.City)
                                                    .AsNoTracking();

            if (query.CityId.HasValue && query.CityId != null)
            {
                queryable = queryable.Where(p => p.CityId == query.CityId);
            }

            int totalItems = await queryable.CountAsync();

            List<Terminal> products = await queryable.Skip((query.Page - 1) * query.ItemsPerPage)
                                                    .Take(query.ItemsPerPage)
                                                    .ToListAsync();

            return new QueryResult<Terminal>
            {
                Items = products,
                TotalItems = totalItems,
            };
        }


        public async Task<List<Terminal>> GetAllTerminals()
        {
            List<Terminal> data = await _context.Terminals.ToListAsync();
            foreach (Terminal terminal in data)
            {
                terminal.City = _context.Cities.FirstOrDefault(v => v.Id == terminal.CityId);
            }
            return data;
        }
    }


}