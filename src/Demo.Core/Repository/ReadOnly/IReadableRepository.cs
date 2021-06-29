using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Proton.Core.Repository
{
    public interface IReadableRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> search = null);
        Task<TEntity> GetById(Guid id);
    }
}
