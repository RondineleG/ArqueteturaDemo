using System.Threading.Tasks;

namespace Demo.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
        void Commit();
    }
}