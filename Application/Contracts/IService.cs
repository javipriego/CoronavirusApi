using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IService<TEntity> 
        where TEntity: IEntity
    {
        Task<List<TEntity>> Get();

        Task<TEntity> Get(Guid id);

        Task Insert(TEntity entity);

        Task Update(Guid id, TEntity entity);
    }
}
