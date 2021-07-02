using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Photos.Application.Commands.Photos
{
    public class AddPhotoCommand : IRequest<int>
    {
        public AddPhotoCommand(string name, string url)
        {
            Name = name;
            URL = url;
            CreateDate = DateTime.Now;

        }
        public string Name { get; }
        public string URL { get;  }
        public DateTime CreateDate { get; }
    }
}
