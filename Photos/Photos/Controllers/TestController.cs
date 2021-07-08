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
using Photos.Application.Extensions;
using Microsoft.Extensions.Caching.Distributed;

namespace Photos.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class TestController : Controller
    {
        private readonly IQRCodeService _qrCode;
        private readonly IBlobService _blobServiceClient;
        private readonly IEventService _eventService;


        public TestController(IBlobService blobServiceClient, IEventService eventService)
        {
            _blobServiceClient = blobServiceClient;
            _eventService = eventService;           
        }

        [HttpGet]
        public async Task<IEnumerable<byte[]>> Get()
        {
            var x = await _eventService.GetAllEvents();


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
