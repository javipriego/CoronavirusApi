using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Contract;
using Infra.Repository;

namespace Domain.Services
{
    public class Service<TEntity>
        : IService<TEntity> where TEntity : IEntity
    {
        protected readonly IRepository<TEntity> _repository;

        public Service(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task<List<TEntity>> Get()
        {
            return await _repository.GetAll();
        }

        public async Task<TEntity> Get(Guid id)
        {
            return await _repository.Get(id);
        }

        public async Task Insert(TEntity entity)
        {
            await _repository.Insert(entity);
        }

        public async Task Update(Guid id, TEntity entity)
        {
            await _repository.Update(id, entity);
        }
    }
}
