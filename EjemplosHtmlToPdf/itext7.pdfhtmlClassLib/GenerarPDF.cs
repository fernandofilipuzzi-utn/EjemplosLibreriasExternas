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
                {
                    using (FileStream pdfDest = File.Open(PathPdf, FileMode.Create))
                    {
                        ConverterProperties properties = new ConverterProperties();

                        MediaDeviceDescription mediaDevice= new MediaDeviceDescription(MediaType.PRINT);
                        mediaDevice.SetResolution(600f);
                        properties.SetMediaDeviceDescription(mediaDevice);
                        properties.SetLimitOfLayouts(0);

                        PdfWriter writer = new PdfWriter(pdfDest);
                        writer.SetCompressionLevel(1);
                        PdfDocument pdf = new PdfDocument(writer);
                        pdf.GetDocumentInfo().SetAuthor("fernando");
                        pdf.SetUserProperties(true);
                        pdf.GetDocumentInfo().SetTitle("prueba");

                        properties.SetBaseUri(System.IO.Path.GetDirectoryName(PathHtml));
                        HtmlConverter.ConvertToPdf(htmlSource, pdf, properties);

                        pdf.Close();
                    }
                }
            }
        }

        public byte[] GenerarPDFFromHTML(string PathHtml)
        {
            byte[] bytes = null;
            string htmlContent = GetHtmlContentFromUrl(PathHtml);

            using (MemoryStream htmlStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(htmlContent)))
            using (MemoryStream pdfDest = new MemoryStream())
            {
                ConverterProperties properties = new ConverterProperties();
                Uri baseUri = new Uri(PathHtml);
                properties.SetBaseUri(baseUri.ToString());

                HtmlConverter.ConvertToPdf(htmlStream, pdfDest, properties);

                bytes = pdfDest.ToArray();
            }

            return bytes;
        }

        private void FromHTML(string url, string pathPdf)
        {
            string htmlContent = GetHtmlContentFromUrl(url);

            using (MemoryStream htmlStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(htmlContent)))
            using (FileStream pdfDest = File.Open(pathPdf, FileMode.Create))
            {
                ConverterProperties properties = new ConverterProperties();
              
                Uri baseUri = new Uri(url);
                properties.SetBaseUri(baseUri.ToString());

                MediaDeviceDescription mediaDeviceDescription = new MediaDeviceDescription(MediaType.PRINT);
                mediaDeviceDescription.SetResolution(400f);
                
                properties.SetMediaDeviceDescription(mediaDeviceDescription);


                PdfWriter writer = new PdfWriter(pdfDest);
                PdfDocument pdf = new PdfDocument(writer);
                pdf.GetDocumentInfo().SetAuthor("fernando");
                pdf.SetUserProperties(true);

                HtmlConverter.ConvertToPdf(htmlStream, pdf, properties);
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
