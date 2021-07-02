using MediatR;
using Photos.Domain.DataBaseEntity;
using Photos.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Photos.Application.Commands.Photos
{
    public class RemovePhotoCommandHandler : IRequestHandler<RemovePhotoCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemovePhotoCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(RemovePhotoCommand request, CancellationToken cancellationToken)
        {
           var photo =  await _unitOfWork.PhotoRepository.FindByIDPhotoAsync(request.Name, cancellationToken);
            if (photo == null)
            {
                return false;
            }
            else{
                 _unitOfWork.PhotoRepository.RemovePhotoAsync(photo);
                return true;
            }           
        }
    }
}
