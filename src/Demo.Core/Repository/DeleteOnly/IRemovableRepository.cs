using System.Threading.Tasks;

namespace Demo.Core.Repository
{
    public interface IRemovableRepository<TEntity> where TEntity : class
    {
        Task Delete(TEntity entity);
    }
}
