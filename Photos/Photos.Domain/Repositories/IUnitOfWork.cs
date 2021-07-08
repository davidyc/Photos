using System;
using System.Collections.Generic;
using System.Text;

namespace Photos.Domain.Repositories
{
    public interface IUnitOfWork
    {
        IPhotoRepository PhotoRepository { get; }
        IEventRepository EventRepository { get; }
    }
}
