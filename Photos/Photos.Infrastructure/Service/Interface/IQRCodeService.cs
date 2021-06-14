using Photos.Domain.QR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Photos.Infrastructure.Service.Interface
{
    public interface IQRCodeService
    {
        QRCodeModel GenerateQRCode(string text);
    }
}
