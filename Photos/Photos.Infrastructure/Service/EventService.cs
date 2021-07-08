﻿using Microsoft.Extensions.Caching.Distributed;
using Photos.Domain.DataBaseEntity;
using Photos.Domain.Repositories;
using Photos.Infrastructure.Service.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
using Photos.Infrastructure.Extensions;

namespace Photos.Infrastructure.Service
{
    public class EventService : IEventService
    {
        private readonly IUnitOfWork _unityOfWork;
        private readonly IDistributedCache _cache;
        private const string RECORDID_CACHE = "EVENTS_DATA";
        public EventService(IUnitOfWork unityOfWork, IDistributedCache cache)
        {
            _unityOfWork = unityOfWork;
            _cache = cache;
        }
        public async Task<IEnumerable<EventEntity>> GetAllEvents()
        {
            var result = await GetFromCahce();

            if (result == null)
            {
                result =  await _unityOfWork.EventRepository.GetAllEventsAsync();
                await _cache.SetRecordAsync(RECORDID_CACHE, result);
            }
            return result;
        }

        private async Task<IEnumerable<EventEntity>> GetFromCahce()
        {
            return await _cache.GetRecordAsync<IEnumerable<EventEntity>>(RECORDID_CACHE);
        }
    }
}
