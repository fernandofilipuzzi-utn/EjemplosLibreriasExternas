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

namespace Ej3
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //https://stackoverflow.com/questions/19700201/convert-html-to-pdf-using-itextsharp

            //https://qawithexperts.com/article/c-sharp/how-to-read-pdf-file-in-c-working-example-using-itextsharp/162
            //https://qawithexperts.com/article/asp-net/email-address-validation-in-c-with-and-without-regex/240

            string PathRecursos = Directory.GetCurrentDirectory() + @"\..\..\reportes";


            string PathHtml = PathRecursos + @"\recibos_logo.html";
            string PathPdf = PathRecursos + @"\salida.pdf";
            string PathImg = PathRecursos + @"\img";

            string htmlContent = File.ReadAllText(PathHtml);

            string cssContent=     ".cabecera\n"+
       " {\n" +
       "     display: flex;\n" +
        "        flex - direction: column;\n" +
      "      padding: 10px 30px 20px 20px;\n" +
       "     border: 1px solid black;\n" +
       "     }";

            PdfCreator.ConvertHtmlToPdf(htmlContent, PathPdf, cssContent);
        }
    }
}
