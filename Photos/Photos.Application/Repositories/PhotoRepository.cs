using Microsoft.EntityFrameworkCore;
using Photos.Domain.DataBaseEntity;
using Photos.Domain.Repositories;
using Photos.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Photos.Application.Repositories
{
    public class PhotoRepository : DataBaseRepository<PhotoEntity, int> , IPhotoRepository
    {
        public PhotoRepository(PhotosDBContext photosDBContext):base(photosDBContext)
        {

        }

        public async Task<IEnumerable<PhotoEntity>> GetPhotosAsync(CancellationToken cancellationToken = default)
        {
            return (IEnumerable<PhotoEntity>)await _photosDBContext.Photos.ToListAsync(cancellationToken);
        }

        public async Task AddPhotoAsync(PhotoEntity photo, CancellationToken cancellationToken = default)
        {
            await _photosDBContext.Photos.AddAsync(photo, cancellationToken);
            await _photosDBContext.SaveChangesAsync();
        }

        public void RemovePhotoAsync(PhotoEntity photo)
        {
            _photosDBContext.Remove(photo);
            _photosDBContext.SaveChanges();
        }

        public async Task<PhotoEntity> FindByIDPhotoAsync(string Name, CancellationToken cancellationToken)
        {
            return await _photosDBContext.Photos.FirstOrDefaultAsync(x=>x.Name == Name, cancellationToken);            
        }
    }
}
