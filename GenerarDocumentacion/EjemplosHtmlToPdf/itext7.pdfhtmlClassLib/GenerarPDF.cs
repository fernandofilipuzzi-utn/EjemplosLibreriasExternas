using iText.Html2pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itext7.pdfhtmlClassLib
{
    public class GenerarPDF
    {
        public void GenerarPDFFromHTML(string PathHtml, string PathPdf)
        {
            using (FileStream htmlSource = File.Open(PathHtml, FileMode.Open))
            using (FileStream pdfDest = File.Open(PathPdf, FileMode.Create))
            {
                ConverterProperties properties = new ConverterProperties();
                properties.SetBaseUri(Path.GetDirectoryName(PathHtml));
                HtmlConverter.ConvertToPdf(htmlSource, pdfDest, properties);
            }
        }
    }
}
