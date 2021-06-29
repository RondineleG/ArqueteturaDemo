using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Proton.Core.Repository
{
    public interface IRepositoryCrud<TEntity> : IDisposable where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> search = null);
        Task<TEntity> GetById(Guid id);

        Task<TEntity> Create(TEntity entity);
        Task<TEntity> Update(TEntity entity);

        Task Delete(TEntity entity);
        Task DeleteById(Guid id);

    }
}


