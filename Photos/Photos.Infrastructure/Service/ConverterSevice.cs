﻿using Photos.Infrastructure.Service.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace Photos.Infrastructure.Service
{
    public class ConverterSevice : IConverter
    {
        public byte[] BitmapToBytesCode(Bitmap qrCodeImage)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                qrCodeImage.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
    }
}
