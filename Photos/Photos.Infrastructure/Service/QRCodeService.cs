using Microsoft.Extensions.Logging;
using Photos.Domain.QR;
using Photos.Infrastructure.Service.Interface;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using static QRCoder.QRCodeGenerator;

namespace Photos.Infrastructure.Service
{
    public class QRCodeService : IQRCodeService
    {
        private readonly ILogger<QRCodeService> _logger;
        private readonly QRCodeGenerator _qrCode;
        private readonly IConverter _converter;

        public QRCodeService()
        {
            //_logger = new Logger<QRCodeService>();
            _qrCode = new QRCodeGenerator();
            _converter = new ConverterSevice();
        }
        public QRCodeService(ILogger<QRCodeService> logger, QRCodeGenerator qrCode, IConverter converter)
        {
            _logger = logger;
            _qrCode = qrCode;
            _converter = converter;
        }


        public QRCodeModel GenerateQRCode(string text)
        {            
            QRCodeData _qrCodeData = _qrCode.CreateQrCode(text, QRCodeGenerator.ECCLevel.L, true, true, EciMode.Iso8859_2);
            QRCode qrCode = new QRCode(_qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            return new QRCodeModel { QRCode = _converter.BitmapToBytesCode(qrCodeImage) };
        }
    }
}
