using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Photos.Application.Commands.Photos
{
    public class RemovePhotoCommand : IRequest<bool>
    {
        public RemovePhotoCommand(string name)
        {
            Name = name;
        }
        public string Name { get; }
    }
}
