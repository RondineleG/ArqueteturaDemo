using Browl.Core.Base;
using Browl.Core.Repository;
using Browl.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Browl.Infrastructure.Base
{
    public class RepositoryCrud<TEntity> : IRepositoryCrud<TEntity> where TEntity : class
    {
        protected RegisterDataContext _context;
        protected readonly DbSet<TEntity> DbSet;

        public RepositoryCrud(RegisterDataContext context)
        {
            _context = context;
            DbSet = context.Set<TEntity>();
        }

        public virtual async Task<TEntity> Update(TEntity entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException($"{nameof(Update)} entity must not be null");
            }

            try
            {
                if(typeof(IAuditEntity).IsAssignableFrom(typeof(TEntity)))
                {
                    ((IAuditEntity)entity).UpdatedDate = DateTime.UtcNow;
                }
                DbSet.Update(entity);
                return entity;
            }
            catch(Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }
        public virtual async Task<TEntity> Create(TEntity entity)
        {

            if(entity == null)
            {
                throw new ArgumentNullException($"{nameof(Create)} entity must not be null");
            }

            try
            {

                if(typeof(IAuditEntity).IsAssignableFrom(typeof(TEntity)))
                {
                    ((IAuditEntity)entity).CreatedDate = DateTime.UtcNow;
                }
                await DbSet.AddAsync(entity);
                return entity;

            }
            catch(Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }
        }


        public virtual async Task Delete(TEntity entity)
        {

            if(typeof(IDeleteEntity).IsAssignableFrom(typeof(TEntity)))
            {
                ((IDeleteEntity)entity).IsDeleted = true;
                DbSet.Update(entity);
            }
            else
            {
                DbSet.Remove(entity);
            }
        }

        public virtual async Task DeleteById(Guid id)
        {
            TEntity entity = await GetById(id);
            await Delete(entity);


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
                    return await DbSet.AsNoTracking().ToListAsync();
                }
                return await DbSet.AsNoTracking().Where(search).ToListAsync();
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
