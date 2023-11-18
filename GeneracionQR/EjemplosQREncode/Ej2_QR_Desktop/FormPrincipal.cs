using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ej3_QR_Desktop
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }
        Bitmap qrCodeImage;
        private void btnQR_Click(object sender, EventArgs e)
        {
            string data = tbCadenaDeEntrada.Text;
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            qrCodeImage = qrCode.GetGraphic(20, Color.Blue, Color.Transparent, true);
            pictureBox1.Image = new Bitmap(qrCodeImage, 200, 200);
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (qrCodeImage != null)
            {
                Bitmap opaqueImage = new Bitmap(qrCodeImage.Width, qrCodeImage.Height);
                using (Graphics g = Graphics.FromImage(opaqueImage))
                {
                    g.Clear(Color.White); 
                    g.DrawImage(qrCodeImage, 0, 0);
                    Clipboard.SetImage(opaqueImage);
                }

                
            }
        }
    }
}
