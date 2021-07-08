using Photos.Domain.DataBaseEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Photos.Infrastructure.Service.Interface
{
    public interface IEventService
    {
        Task<IEnumerable<EventEntity>> GetAllEvents();
    }
}
