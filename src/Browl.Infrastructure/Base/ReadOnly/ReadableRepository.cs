using Browl.Core.Repository;
using Browl.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProtonDemo.Repository.Base
{
    public class ReadableRepository<TEntity> : IDisposable, IReadableRepository<TEntity> where TEntity : class
    {
        protected RegisterDataContext _context;

        public ReadableRepository(RegisterDataContext context)
        {
            _context = context;
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> search = null)
        {

            try
            {
                if(search == null)
                {
                    return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
                }
                return await _context.Set<TEntity>().AsNoTracking().Where(search).ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }

        }

        public void Dispose()
        {
            _context?.DisposeAsync();
        }


    }
}
