using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Photos.Infrastructure.Service.Interface
{
    public interface IConverterService
    {
        byte[] BitmapToBytesCode(Bitmap qrCodeImage);
    }
}
