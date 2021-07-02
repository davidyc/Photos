using Photos.Domain.DataBaseEntity;
using Photos.Domain.DataBaseEntity.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Photos.Domain.Repositories
{
    public interface IPhotoRepository : IDataBaseRepository<PhotoEntity, int>
    {
        Task<IEnumerable<PhotoEntity>> GetPhotosAsync(CancellationToken cancellationToken = default);
        Task AddPhotoAsync(PhotoEntity photo, CancellationToken cancellationToken);
        void RemovePhotoAsync(PhotoEntity photo);
        Task<PhotoEntity> FindByIDPhotoAsync(string name, CancellationToken cancellationToken);
    }
}
