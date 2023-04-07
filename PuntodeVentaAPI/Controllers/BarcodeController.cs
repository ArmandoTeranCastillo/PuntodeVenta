using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System;
using BarcodeLib;
using Microsoft.AspNetCore.Authorization;

namespace PuntodeVentaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarcodeController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public IActionResult GenerateBarcode(string code)
        {
            Barcode barcode = new Barcode();
            Image img = barcode.Encode(TYPE.CODE128, code, Color.Black, Color.White, 2500, 1000);
            var data = ConvertImageToBites(img);
            return File(data, "image/jpeg");
        }

        private byte[] ConvertImageToBites(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }

        }
    }
}

