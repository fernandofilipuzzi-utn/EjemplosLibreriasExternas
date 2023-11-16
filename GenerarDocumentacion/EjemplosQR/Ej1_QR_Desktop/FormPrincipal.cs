using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
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
        string pathExcel;
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {


        }

        private void btnQR_Click(object sender, EventArgs e)
        {
            GenerarQR gen = new GenerarQR();

            byte[] bytes = gen.Generar("Prueba");

            using (MemoryStream ms = new MemoryStream(bytes))
            {
                Image imagen = Image.FromStream(ms);
                pictureBox1.Image = new Bitmap(imagen, 200, 200);
            }

            
        }


        
    }
}