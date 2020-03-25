using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public interface IRepository<TEntity> 
        where TEntity: IEntity
    {
        Task<List<TEntity>> GetAll();

        Task<TEntity> Get(Guid id);
        
        Task Insert(TEntity value);

        Task Update(Guid id, TEntity entity);
    }
}