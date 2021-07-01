using MediatR;
using Photos.Domain.DataBaseEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Photos.Application.Queries.Photos
{
    public class GetPhotosQuery : IRequest<IEnumerable<PhotoEntity>>
    {       
    }
}
