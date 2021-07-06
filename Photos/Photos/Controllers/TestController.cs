using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
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
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Configuration;

namespace Photos.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class TestController : Controller
    {
        private readonly IQRCodeService _qrCode;
        private readonly IBlobService _blobServiceClient;       

        public TestController(IBlobService blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        [HttpGet]
        public IEnumerable<byte[]> Get()
        {        

            return null;
        }


        private static void Static()
        {
            

        }

    }
    public class ConnectionStrings
    {
        public String PhotosDBContext { get; set; }
    }
}
