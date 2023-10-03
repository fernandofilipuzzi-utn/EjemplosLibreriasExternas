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

/*seguir viendo
 * https://stackoverflow.com/questions/13515210/what-is-the-difference-between-lowagie-and-itext/13515403#13515403
 *         https://html2pdf.com/
 *         https://docs.apryse.com/documentation/samples/cs/HTML2PDFTest
 */

namespace Ej4
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void btnRecibosImagen_Click(object sender, EventArgs e)
        {
            //HTML2PDF  
            //Es una herramienta HTML2PDF sencilla que permite a las personas crear plantillas sencillas en HTML para crear informes en PDF.
            //https://stackoverflow.com/questions/32591581/itextsharp-xmlworker-does-not-work-on-css-border-collapse-collapse

            string PathRecursos = Directory.GetCurrentDirectory() + @"\..\..\reportes";
            string PathHtml = PathRecursos + @"\recibos_logo.html";
            string PathPdf = PathRecursos + @"\salida.pdf";
                        

            SelectPdf.HtmlToPdf converter = new SelectPdf.HtmlToPdf();
            ///SelectPdf.PdfDocument doc = converter.ConvertUrl("http://selectpdf.com");
            ///
            SelectPdf.PdfDocument doc = converter.ConvertUrl(PathHtml);

            doc.Save(PathPdf);
            doc.Close();

            MessageBox.Show("listo");

            /*
            Thank you for using Select.Pdf Html To Pdf Converter for .NET - Community Edition.

            Online demo C#: https://selectpdf.com/html-to-pdf/demo/
            Online demo Vb.Net: https://selectpdf.com/html-to-pdf/demo-vb/
            Online documentation: https://selectpdf.com/html-to-pdf/docs/


            With Select.Pdf is very easy to convert any web page to a pdf document. The code is as simple as this:

                        SelectPdf.HtmlToPdf converter = new SelectPdf.HtmlToPdf();
                        SelectPdf.PdfDocument doc = converter.ConvertUrl("http://selectpdf.com");
                        doc.Save("test.pdf");
                        doc.Close();

            IMPORTANT: Please note that THIS IS NOT A FREE TRIAL of our commercial library. This is a different, FREE product, that contains less features than the full library. 
            If you want to test our full SelectPdf Library for .NET use one of the following urls:

            https://selectpdf.com/pdf-library-for-net/
            https://www.nuget.org/packages/Select.Pdf.NetCore/
            https://www.nuget.org/packages/Select.Pdf/

            IMPORTANT: This package works for .NET Framework up to version 4.5. To use newer .NET Framework versions, .NET Core, .NET 5, .NET 6 use the following package:
            https://www.nuget.org/packages/Select.HtmltoPdf.NetCore/

            For complete product information, take a look at https://selectpdf.com.
            For support, contact us at support@selectpdf.com.
            */
        }
    }
}
