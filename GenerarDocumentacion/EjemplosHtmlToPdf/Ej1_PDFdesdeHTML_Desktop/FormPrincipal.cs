
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
        string PathHtml = "";
        string PathPdf = "";

        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            PathHtml = Path.GetFullPath($@"..\..\plantillas");
            PathPdf = Path.GetFullPath(@"salida\");

            openFileDialog1.InitialDirectory = Path.GetFullPath(PathHtml);
        }

        private void btnGenerarPDF_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex != -1)
            {
                try
                {
                    if (File.Exists(PathHtml))
                    {
                        vwPDF.Source = new Uri(Path.Combine(Application.StartupPath,"nofile.html"));

                        PathPdf = Path.Combine(Path.GetDirectoryName(PathPdf), "salida.pdf");

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

                        lnklbficheroPDF.Text = Path.GetFileName(PathPdf);
                        vwPDF.Source = new Uri(PathPdf);
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
            string path = PathHtml;
            try
            {
                if (File.Exists(path))
                {
                    //System.Diagnostics.Process.Start(@"notepad.exe", PathHtml);

                    var processInfo = new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = "code",
                        Arguments = Path.GetDirectoryName(PathHtml),
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
                PathHtml = Path.GetFullPath(pathHTML);
            }
        }
    }
}
