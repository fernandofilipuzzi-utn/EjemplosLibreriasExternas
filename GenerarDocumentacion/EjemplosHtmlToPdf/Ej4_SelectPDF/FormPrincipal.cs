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



namespace Ej4_SelectPDF
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void btnGenerarPDF_Click(object sender, EventArgs e)
        {
            string PathHtml = Path.GetFullPath(@"..\..\plantillas\recibos_logo.html");
            string PathPdf = Path.GetFullPath(@"..\..\salida\recibos_logo.pdf");

            try
            {
                if (File.Exists(PathHtml))
                {
                    SelectPdf.HtmlToPdf converter = new SelectPdf.HtmlToPdf();

                    SelectPdf.PdfDocument doc = converter.ConvertUrl(PathHtml);

                    doc.Save(PathPdf);
                    doc.Close();

                    MessageBox.Show("listo");

                    linkLabel1.Text = Path.GetFullPath(PathPdf);
                }
                else
                {
                    MessageBox.Show("No existe:"+PathHtml);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string path = linkLabel1.Text;

            try
            {
                if (File.Exists(path))
                {
                    System.Diagnostics.Process.Start(path);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
