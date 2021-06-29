using Demo.Core.Business;
using Demo.Core.Repository;
using Demo.Core.UnitOfWork;
using Demo.Register.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Demo.Register.Domain.Base
{
    public class BusinessCrud<TEntity> : BaseNotification, IBusinessCrud<TEntity> where TEntity : class
    {

        private readonly IRepositoryCrud<TEntity> _baseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BusinessCrud(IRepositoryCrud<TEntity> baseRepository,
                            IUnitOfWork unitOfWork,
                            INotifier notifier) : base(notifier)
        {
            _baseRepository = baseRepository;
            _unitOfWork = unitOfWork;

        }

        public virtual async Task Update(TEntity entity)
        {
            await _baseRepository.Update(entity);
            await _unitOfWork.CompleteAsync();
        }


        public virtual async Task Delete(TEntity entity)
        {
            await _baseRepository.Delete(entity);
            await _unitOfWork.CompleteAsync();
        }

        public virtual async Task DeleteById(Guid id)
        {
            var entity = await GetById(id);
            await _baseRepository.Delete(entity);
            await _unitOfWork.CompleteAsync();
        }

        public virtual async Task<TEntity> Create(TEntity entity)
        {
            await _baseRepository.Create(entity);
            await _unitOfWork.CompleteAsync();
            return entity;
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await _baseRepository.GetById(id); ;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> search = null)
        {
            if (search == null)
            {
                return await _baseRepository.GetAll();
            }
            return await _baseRepository.GetAll(search);
        }


    }
}
