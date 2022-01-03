using System.Threading.Tasks;

namespace Browl.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
        void Commit();
    }
}