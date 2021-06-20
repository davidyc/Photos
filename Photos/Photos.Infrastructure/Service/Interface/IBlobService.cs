using Azure.Storage.Blobs.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Photos.Infrastructure.Service.Interface
{
    public interface IBlobService
    {
        Task<BlobDownloadResult> DownloadContentAsync(string name);
        Task<BlobContentInfo> UploadAsync(string fileName, Stream stream);
        Task<BlobContentInfo> UploadAsync(string fileName, string filPath);
    }
}
