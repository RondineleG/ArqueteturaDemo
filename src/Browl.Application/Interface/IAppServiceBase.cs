
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Browl.Application.Interface
{
    public interface IAppServiceBase<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> search = null);
        Task<TEntity> GetById(Guid id);
        Task Update(TEntity entity);
        Task<TEntity> Create(TEntity entity);
        Task Delete(TEntity entity);
        Task DeleteById(Guid id);

    }
}
