using Demo.Core.UnitOfWork;
using Demo.Register.Infrastructure.Context;
using System.Threading.Tasks;

namespace Demo.Register.Infrastructure.UnitOfWork
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