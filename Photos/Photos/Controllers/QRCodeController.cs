using Microsoft.AspNetCore.Mvc;
using Photos.Domain.QR;
using Photos.Infrastructure.Service.Interface;

namespace Photos.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class QRCodeController : Controller
    {
        private readonly IQRCodeService _qrCode;

        public QRCodeController(IQRCodeService qrCode)
        {
            _qrCode = qrCode;
        }

        [HttpGet]
        public QRCodeModel Get(string text)
        {
            return _qrCode.GenerateQRCode(text);
        }


    }
}
