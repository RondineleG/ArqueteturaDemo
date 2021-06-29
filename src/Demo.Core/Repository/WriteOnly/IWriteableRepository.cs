using System.Threading.Tasks;

namespace Demo.Core.Repository
{
    public interface IWriteableRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Create(TEntity entity);
        Task<TEntity> Update(TEntity entity);
    }
}
