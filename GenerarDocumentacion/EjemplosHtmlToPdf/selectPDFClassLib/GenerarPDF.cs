using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SelectPdf;

namespace selectPDFClassLib
{
    public class GenerarPDF
    {
        public void GenerarPDFFromHTML(string PathHtml,string PathPdf)
        {
            HtmlToPdf converter = new HtmlToPdf();

            PdfDocument doc = converter.ConvertUrl(PathHtml);

            doc.Save(PathPdf);
            doc.Close();
        }
    }
}
