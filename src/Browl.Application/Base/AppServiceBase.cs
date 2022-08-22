using Browl.Application.Interface;
using Browl.Core.Business;
using Browl.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Browl.Application.Base
{
    public class AppServiceBase<TEntity> : BaseNotification, IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IBusinessCrud<TEntity> _serviceBase;

        public AppServiceBase(IBusinessCrud<TEntity> serviceBase,
                              INotifier notifier) : base(notifier)
        {
            _serviceBase = serviceBase;
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            await _serviceBase.Create(entity);
            return entity;
        }

        public async Task Delete(TEntity entity)
        {
            await _serviceBase.Delete(entity);
        }

        public async Task DeleteById(Guid id)
        {
            var entity = await GetById(id);
            await _serviceBase.Delete(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> search = null)
        {
            if(search == null)
            {
                return await _serviceBase.GetAll();
            }
            return await _serviceBase.GetAll(search);
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await _serviceBase.GetById(id);
            ;
        }

        public async Task Update(TEntity entity)
        {
            await _serviceBase.Update(entity);
        }
    }
}
