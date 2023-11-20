using iText.Html2pdf;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.StyledXmlParser.Css.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace itext7.pdfhtmlClassLib
{
    public class GenerarPDF
    {
        public void GenerarPDFFromHTML(string PathHtml, string PathPdf)
        {
            if (PathHtml.StartsWith("http://") == true || PathHtml.StartsWith("https://") == true)
            {
                FromHTML(PathHtml, PathPdf);
            }
            else
            {
                using (FileStream htmlSource = File.Open(PathHtml, FileMode.Open))
                using (FileStream pdfDest = File.Open(PathPdf, FileMode.Create))
                {
                    ConverterProperties properties = new ConverterProperties();

                    MediaDeviceDescription mediaDeviceDescription = new MediaDeviceDescription(MediaType.PRINT);
                    properties.SetMediaDeviceDescription(mediaDeviceDescription);

                    properties.SetBaseUri(System.IO.Path.GetDirectoryName(PathHtml));
                    HtmlConverter.ConvertToPdf(htmlSource, pdfDest, properties);
                }
            }
        }

        /*
        public void createPdf(Uri url, String dest)
        {
            PdfWriter writer = new PdfWriter(dest);
            PdfDocument pdf = new PdfDocument(writer);
            PageSize pageSize = new PageSize(850, 1700);
            pdf.SetDefaultPageSize(pageSize);
            ConverterProperties properties = new ConverterProperties();
            MediaDeviceDescription mediaDeviceDescription = new MediaDeviceDescription(MediaType.PRINT);
            mediaDeviceDescription.SetWidth(pageSize.GetWidth());
            properties.SetMediaDeviceDescription(mediaDeviceDescription);
            HtmlConverter.ConvertToPdf(stream, pdf, properties);
        }
        */

        private void FromHTML(string url, string pathPdf)
        {
            string htmlContent = GetHtmlContentFromUrl(url);

            using (MemoryStream htmlStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(htmlContent)))
            using (FileStream pdfDest = File.Open(pathPdf, FileMode.Create))
            {
                ConverterProperties properties = new ConverterProperties();
                Uri baseUri = new Uri(url);
                properties.SetBaseUri(baseUri.ToString());

                HtmlConverter.ConvertToPdf(htmlStream, pdfDest, properties);
            }
        }

        private string GetHtmlContentFromUrl(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsStringAsync().Result;
            }
        }
    }
}
