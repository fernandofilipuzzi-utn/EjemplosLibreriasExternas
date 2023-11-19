
using selectPDFClassLib;
using itext7.pdfhtmlClassLib;

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



namespace Ej1_PDFdesdeHTML_Desktop
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void btnGenerarPDF_Click(object sender, EventArgs e)
        {
            string text = comboBox1.Text;

            string PathHtml = Path.GetFullPath($@"..\..\plantillas\{text}\recibos_logo.html");
            string PathPdf = Path.GetFullPath(@"..\..\salida\recibos_logo.pdf");

            if (comboBox2.SelectedIndex != -1)
            {
                try
                {
                    if (File.Exists(PathHtml))
                    {

                        if (comboBox2.SelectedIndex == 0)
                        {
                            selectPDFClassLib.GenerarPDF gen = new selectPDFClassLib.GenerarPDF();
                            gen.GenerarPDFFromHTML(PathHtml, PathPdf);
                        }
                        else
                        {
                            itext7.pdfhtmlClassLib.GenerarPDF gen = new itext7.pdfhtmlClassLib.GenerarPDF();
                            gen.GenerarPDFFromHTML(PathHtml, PathPdf);
                        }


                        MessageBox.Show("listo");

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
            else
            {
                MessageBox.Show("Seleccione una librería");
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
