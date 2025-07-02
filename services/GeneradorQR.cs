using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace WS_asistens.services
{
    public class GeneradorQR
    {
        public static string GenerarQR(string ci)
        {
            string contenido = $"{ci}";
            using (var qrGenerator = new QRCodeGenerator())
            {
                var datosQR = qrGenerator.CreateQrCode(contenido, QRCodeGenerator.ECCLevel.Q);
                var qrCode = new QRCode(datosQR);

                using (Bitmap imagenQR = qrCode.GetGraphic(20))
                using (MemoryStream ms = new MemoryStream())
                {
                    imagenQR.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    return Convert.ToBase64String(ms.ToArray());
                }    
            }
        }
    }
}