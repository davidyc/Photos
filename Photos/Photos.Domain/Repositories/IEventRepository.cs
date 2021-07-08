using Photos.Domain.DataBaseEntity;
using Photos.Domain.DataBaseEntity.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Photos.Domain.Repositories
{
    public interface IEventRepository : IDataBaseRepository<EventEntity, int>
    {
        Task<IEnumerable<EventEntity>> GetAllEventsAsync(CancellationToken cancellationToken = default);
    }    
}
