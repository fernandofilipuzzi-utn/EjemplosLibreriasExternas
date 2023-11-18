using QRCoder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QRCoder_ClassLib
{
    public class GenerarQR
    {
        public byte[] Generar(string data, int sizeModulo = 20)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(sizeModulo);

            byte[] imageBytes = new byte[0];
            using (MemoryStream ms = new MemoryStream())
            {
                qrCodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                imageBytes = ms.ToArray();
            }
            return imageBytes;
        }
    }
}
