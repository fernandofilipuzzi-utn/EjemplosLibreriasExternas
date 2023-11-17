using QRCoder_ClassLib;
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


namespace Ej1_QR_Desktop
{
    public partial class FormPrincipal : Form
    {

        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void btnQR_Click(object sender, EventArgs e)
        {
            GenerarQR gen = new GenerarQR();

            string cadenaQR = "cadena1;cadena2;";
            byte[] bytes = gen.Generar(cadenaQR);

            using (MemoryStream ms = new MemoryStream(bytes))
            {
                Image imagen = Image.FromStream(ms);
                pictureBox1.Image = new Bitmap(imagen, 200, 200);
            }
        }
    }
}