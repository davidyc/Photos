using System;
using System.Collections.Generic;
using System.Text;
using Azure.Storage.Blobs.Models;

namespace Photos.Domain.Blob
{
    public class BlobDownloadModel
    {
        public string Name { get; set; }
        public byte[] BytesArray { get; set; }
    }
}
