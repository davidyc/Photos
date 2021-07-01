using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IUnitOfWork _unitOfWork;

        public PhotosController(IBlobService blobServiceClient, IUnitOfWork unitOfWork)
        {
            _blobServiceClient = blobServiceClient;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IEnumerable<BlobDownloadModel>> Get()
        {
            var blobDownloadModels = new List<BlobDownloadModel>();
            var photos = _unitOfWork.PhotoRepository.GetPhotosAsync().Result;
            foreach (var photo in photos)
            {
                var file = await _blobServiceClient.GetFileByNameAsync(photo.Name);
                blobDownloadModels.Add(file);
            }
            return blobDownloadModels;
        }

        [HttpPost]
        public  BlobContentInfo Post([FromForm] IFormFile body)
        {
            return _blobServiceClient.UploadAsync(body.FileName, body.OpenReadStream()).Result;
        }

        [HttpDelete]
        public bool Delete(string fileName)
        {
            return _blobServiceClient.DeleteFileAsync(fileName).Result;
        }
    }
}
