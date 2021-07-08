using Photos.Domain.DataBaseEntity;
using Photos.Domain.Repositories;
using Photos.Infrastructure.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Photos.Infrastructure.Service
{
    public class EventService : IEventService
    {
        private readonly IUnitOfWork _unityOfWork;
        public EventService(IUnitOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }
        public async Task<IEnumerable<EventEntity>> GetAllEvents()
        {
            return await _unityOfWork.EventRepository.GetAllEventsAsync();
        }
    }
}
