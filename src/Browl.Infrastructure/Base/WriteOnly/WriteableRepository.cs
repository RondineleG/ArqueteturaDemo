using Browl.Core.Repository;
using Browl.Infrastructure.Context;
using System;
using System.Threading.Tasks;

namespace Browl.Infrastructure.Base
{
    public class WriteableRepository<TEntity> : IDisposable, IWriteableRepository<TEntity> where TEntity : class
    {
        protected RegisterDataContext _context;

        public WriteableRepository(RegisterDataContext context)
        {
            _context = context;
        }

        public virtual async Task<TEntity> Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(Update)} entity must not be null");
            }

            try
            {
                _context.Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }
        public virtual async Task<TEntity> Create(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(Create)} entity must not be null");
            }

            try
            {
                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }
        }

        public void Dispose()
        {
            _context?.DisposeAsync();
        }


    }
}
