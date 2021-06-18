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
        public bool Get()
        {
            var x = _blobServiceClient.GetBlobAsync("Links.txt").Result;

            return true;
        }


    }
}
