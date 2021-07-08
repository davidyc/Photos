using Photos.Application.Repositories;
using Photos.Domain.Repositories;
using Photos.Infrastructure;

namespace Photos.Application.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PhotosDBContext _dbContext;
        private IPhotoRepository _photoRepository;
        private IEventRepository _eventRepository;


        public UnitOfWork(PhotosDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IPhotoRepository PhotoRepository
        {
            get { return _photoRepository = new PhotoRepository(_dbContext); }
        }

        public IEventRepository EventRepository 
        {
            get { return _eventRepository = new EventRepository(_dbContext); }
        }
    }
}