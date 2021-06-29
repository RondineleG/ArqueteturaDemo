using Demo.Core.Base;
using Demo.Core.Repository;
using Demo.Register.Infrastructure.Context;
using System;
using System.Threading.Tasks;

namespace ProtonDemo.Repository.Base
{
    public class RemovableRepository<TEntity> : IDisposable, IRemovableRepository<TEntity> where TEntity : class
    {
        protected RegisterDataContext _context;

        public RemovableRepository(RegisterDataContext context)
        {
            _context = context;
        }

        public virtual async Task Delete(TEntity entity)
        {

            if (typeof(IDeleteEntity).IsAssignableFrom(typeof(TEntity)))
            {
                ((IDeleteEntity)entity).IsDeleted = true;
                _context.Update(entity);
            }
            else
                _context.Remove(entity);

            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.DisposeAsync();
        }
    }
}
