using System.Threading.Tasks;

namespace Proton.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
        void Commit();
    }
}