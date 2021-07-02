using Azure.Storage.Blobs.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Photos.Application.Commands.Photos;
using Photos.Application.Queries.Photos;
using Photos.Domain.Blob;
using Photos.Domain.Repositories;
using Photos.Infrastructure.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Photos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhotosController : Controller
    {
        private readonly IBlobService _blobServiceClient;
        private readonly IMediator _mediator;

        public PhotosController(IBlobService blobServiceClient, IMediator mediator)
        {
            _blobServiceClient = blobServiceClient;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<BlobDownloadModel>> Get()
        {
            var blobDownloadModels = new List<BlobDownloadModel>();
            var photos = await _mediator.Send(new GetPhotosQuery());

            //TODO  перести в метод
            foreach (var photo in photos)
            {
                var file = await _blobServiceClient.GetFileByNameAsync(photo.Name);
                blobDownloadModels.Add(file);
            }
            return blobDownloadModels;
        }

        [HttpPost]
        public BlobContentInfo Post([FromForm] IFormFile body)
        {
            var fileName = $"{Guid.NewGuid()}_{body.FileName}";
            _mediator.Send(new AddPhotoCommand(fileName, "URL"));
            return _blobServiceClient.UploadAsync(fileName, body.OpenReadStream()).Result;
        }

        [HttpDelete("{fileName}")]
        public bool Delete(string fileName)
        {
            _mediator.Send(new RemovePhotoCommand(fileName));
            return _blobServiceClient.DeleteFileAsync(fileName).Result;
        }
    }
}
