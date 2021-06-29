using System.Threading.Tasks;

namespace Proton.Core.Repository
{
    public interface IRemovableRepository<TEntity> where TEntity : class
    {
        Task Delete(TEntity entity);
    }
}
