
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
        string PathFicheroLocalHtml = "";
        string PathPdf = "";
        string PathHtmlOrigen = "";
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            PathFicheroLocalHtml = Path.GetFullPath($@"..\..\plantillas");
            PathPdf = Path.GetFullPath(@"salida\");

            openFileDialog1.InitialDirectory = Path.GetFullPath(PathFicheroLocalHtml);
            cbTipoLibreria.SelectedIndex = 0;
        }

        private void btnGenerarPDF_Click(object sender, EventArgs e)
        {
            vwPDF.Source = new Uri(Path.Combine(Application.StartupPath, "nofile.html"));

            if (rbURL.Checked == true)
            {
                PathHtmlOrigen = textBox1.Text;
            }
            else
            {
                PathHtmlOrigen = PathFicheroLocalHtml;
                if (File.Exists(PathFicheroLocalHtml) == false)
                {
                    MessageBox.Show("No existe:" + PathFicheroLocalHtml);
                    return;
                }
            }

            if (cbTipoLibreria.SelectedIndex != -1)
            {
                try
                {
                    PathPdf = Path.Combine(Path.GetDirectoryName(PathPdf), "salida.pdf");

                    if (cbTipoLibreria.SelectedIndex == 1)
                    {
                        selectPDFClassLib.GenerarPDF gen = new selectPDFClassLib.GenerarPDF();
                        gen.GenerarPDFFromHTML(PathHtmlOrigen, PathPdf);
                    }
                    else
                    {
                        itext7.pdfhtmlClassLib.GenerarPDF gen = new itext7.pdfhtmlClassLib.GenerarPDF();
                        gen.GenerarPDFFromHTML(PathHtmlOrigen, PathPdf);
                    }

                    lnklbficheroPDF.Text = Path.GetFileName(PathPdf);
                    vwPDF.Source = new Uri(PathPdf);

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

        private void lnklbficheroPDF_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string path = PathPdf;

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

        private void lnklbficheroHTML_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string path = PathFicheroLocalHtml;
            try
            {
                if (File.Exists(path))
                {
                    //System.Diagnostics.Process.Start(@"notepad.exe", PathFicheroLocalHtml);

                    var processInfo = new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = "code",
                        Arguments = Path.GetDirectoryName(PathFicheroLocalHtml),
                    };

                    System.Diagnostics.Process.Start(processInfo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string pathHTML = openFileDialog1.FileName;
                lnklbficheroHTML.Text = Path.GetFileName(pathHTML);
                PathFicheroLocalHtml = Path.GetFullPath(pathHTML);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
