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
            if (logo == null)
            {
                qrCodeImage = qrCode.GetGraphic(20, Color.Blue, Color.Transparent, true);
            }
            else
            {
                Bitmap logoBitmap = new Bitmap(logo);

                qrCodeImage = qrCode.GetGraphic(20, pbColor.BackColor, pbBackColor.BackColor,
                        RecolorImage(logoBitmap, Color.Black, pbColor.BackColor, pbBackColor.BackColor));

            }
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

        Image logo;
        private void btnLoadLogo_Click(object sender, EventArgs e)
        {
            if (openFileDialogLogo.ShowDialog() == DialogResult.OK)
            {
                logo = Image.FromFile(openFileDialogLogo.FileName);
                pbLogo.Image = new Bitmap(logo, pbLogo.Width, pbLogo.Height);
            }
        }

        private Bitmap RecolorImage(Bitmap original, Color fromColor, Color toColor, Color BackGround)
        {
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            for (int x = 0; x < original.Width; x++)
            {
                for (int y = 0; y < original.Height; y++)
                {
                    Color pixelColor = original.GetPixel(x, y);

                    if (IsGrayToDark(pixelColor))
                    {
                        newBitmap.SetPixel(x, y, toColor);
                    }
                    else
                    {
                        newBitmap.SetPixel(x, y, BackGround);
                    }
                }
            }

            return newBitmap;
        }

        private bool IsGrayToDark(Color color)
        {
            int threshold = 100;
            int luminance = (int)(0.299 * color.R + 0.587 * color.G + 0.114 * color.B);
            return luminance < threshold;
        }

        private void obDefinirColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                if(sender== pbColor)
                    pbColor.BackColor = colorDialog1.Color;
                else
                    pbBackColor.BackColor = colorDialog1.Color;
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            pbLogo.Image = null;
            logo = null;
        }
    }
}
