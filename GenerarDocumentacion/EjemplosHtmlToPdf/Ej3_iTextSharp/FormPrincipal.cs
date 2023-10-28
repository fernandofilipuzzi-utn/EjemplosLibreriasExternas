using iText.Kernel.Pdf;
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

namespace Ej3_iTextSharp
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
            string PathPdf = Path.GetFullPath(@"..\..\salida\salida.pdf");
            try
            {
                if (File.Exists(PathHtml))
                {
                    string htmlContent = File.ReadAllText(PathHtml);

                    string cssContent = ".cabecera\n" +
                                        " {\n" +
                                        "     display: flex;\n" +
                                        "        flex - direction: column;\n" +
                                        "      padding: 10px 30px 20px 20px;\n" +
                                        "     border: 1px solid black;\n" +
                                        "     }";
                    PdfCreator.ConvertHtmlToPdf(htmlContent, PathPdf, cssContent);

                    linkLabel1.Text = Path.GetFullPath(PathPdf);
                }
                else
                {
                    MessageBox.Show("No existe:" + PathHtml);
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
