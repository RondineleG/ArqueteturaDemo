using System.Threading.Tasks;

namespace Proton.Core.Repository
{
    public interface IWriteableRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Create(TEntity entity);
        Task<TEntity> Update(TEntity entity);
    }
}
