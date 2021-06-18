using Azure.Storage.Blobs.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Photos.Infrastructure.Service.Interface
{
    public interface IBlobService
    {
        Task<BlobDownloadResult> GetBlobAsync(string name);
    }
}
