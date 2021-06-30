using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Photos.Domain.DataBaseEntity.Domain
{
    public interface IDataBaseRepository<TEntity, TKey>
          where TEntity : class, IEntity, new()
          where TKey : struct
    {
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<TEntity> FindAsync(TKey key, CancellationToken cancellationToken = default);

        Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);

        void Update(TEntity entity);

        void Remove(TEntity entity);
      
    }
}
