using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public PhotosController(IBlobService blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        [HttpGet]
        public IEnumerable<byte[]> Get()
        {
            var allFiles = _blobServiceClient.GetAllFile().Result;
            var arrFileBytes = new List<byte[]>();
            foreach (var item in allFiles)
            {
                arrFileBytes.Add(item.Content.ToArray());
            }

            return arrFileBytes;
        }

        [HttpPost]
        public  BlobContentInfo Post([FromForm] IFormFile body)
        {
            return _blobServiceClient.UploadAsync(body.FileName, body.OpenReadStream()).Result;
        }
    }
}
