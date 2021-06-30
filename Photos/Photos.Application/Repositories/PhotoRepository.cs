using Microsoft.EntityFrameworkCore;
using Photos.Domain.DataBaseEntity;
using Photos.Domain.Repositories;
using Photos.Infrastructure;
using System;
using System.Collections.Generic;
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
    }
}
