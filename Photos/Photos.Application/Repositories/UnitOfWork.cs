using Photos.Application.Repositories;
using Photos.Domain.Repositories;
using Photos.Infrastructure;

namespace Photos.Application.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PhotosDBContext _dbContext;
        private IPhotoRepository _photoRepository;

        public UnitOfWork(PhotosDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IPhotoRepository PhotoRepository
        {
            get { return _photoRepository = new PhotoRepository(_dbContext); }
        }
    }
}