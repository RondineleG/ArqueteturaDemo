using Browl.Core.UnitOfWork;
using Browl.Infrastructure.Context;
using System.Threading.Tasks;

namespace Browl.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RegisterDataContext _registerDataContext;

        public UnitOfWork(RegisterDataContext registerDataContext)
        {
            _registerDataContext = registerDataContext;
        }

        public void Commit()
        {
            _registerDataContext.SaveChanges();
        }

        public async Task CompleteAsync()
        {
            await _registerDataContext.SaveChangesAsync();
        }
    }
}