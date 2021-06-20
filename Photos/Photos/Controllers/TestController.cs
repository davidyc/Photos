using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;
using Photos.Domain.DataBaseEntity;
using Photos.Domain.QR;
using Photos.Infrastructure.Service;
using Photos.Infrastructure.Service.Interface;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Photos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : Controller
    {
        private readonly IQRCodeService _qrCode;
        private readonly IBlobService _blobServiceClient;       

        public TestController(IBlobService blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        [HttpGet]
        public QRCodeModel Get()
        {
           // var x = _blobServiceClient.UploadAsync(Guid.NewGuid() + ".jpg", @"C:\Users\Sergey_Davydov2\Desktop\Grow\Layers\23306172.jpg").Result;
           var x = _blobServiceClient.DownloadContentAsync("003cab19-30d9-4e45-9d32-38dca288bf65.jpg");
            var r = x.Result.Content.ToArray();
            return new QRCodeModel { QRCode = r };
        }


    }
}
