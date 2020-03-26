using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infra.Repository.Cached
{
    public class Repository<TEntity>
        : IRepository<TEntity> where TEntity : IEntity
    {
        private List<TEntity> _cachedList;

        public Repository(List<TEntity> cachedList)
        {
            _cachedList = cachedList;
        }
        
        public async Task<TEntity> Get(Guid id)
        {
            return  _cachedList.Find(x => x.Id == id);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return _cachedList;
        }

        public async Task Insert(TEntity value)
        {
            _cachedList.Add(value);
        }

        public async Task Update(Guid id, TEntity entity)
        {
            _cachedList.Remove(_cachedList.Find(x => x.Id == id));
            _cachedList.Add(entity);
        }
    }
}
