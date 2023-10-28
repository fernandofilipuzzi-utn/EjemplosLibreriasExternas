using iTextSharp.text;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.tool.xml.css;
using iTextSharp.tool.xml.html;
using iTextSharp.tool.xml.parser;
using iTextSharp.tool.xml.pipeline.css;
using iTextSharp.tool.xml.pipeline.end;
using iTextSharp.tool.xml.pipeline.html;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Xsl;

namespace Ej2
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var tagProcessors = (DefaultTagProcessorFactory)Tags.GetHtmlTagProcessorFactory();
            tagProcessors.RemoveProcessor(HTML.Tag.IMG);
            tagProcessors.AddProcessor(HTML.Tag.IMG, new CustomImageTagProcessor());

            /*
            string html;

            using (var xsltStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("EmbeddedImage.Resources.Pdf.xslt"))
            {
                var reader = XmlReader.Create(xsltStream);
                var xslt = new XslCompiledTransform();
                xslt.Load(reader);

                using (var ms = new MemoryStream())
                {
                    xslt.Transform(new XmlDocument(), new XsltArgumentList(), ms);
                    ms.Position = 0;
                    using (var r = new StreamReader(ms))
                    {
                        html = r.ReadToEnd();
                    }
                }
            }
            */
            string PathRecursos = Directory.GetCurrentDirectory() + @"\..\..\reportes";
            string PathHtml = PathRecursos + @"\recibos_logo.html";
            string PathPdf = PathRecursos + @"\salida.pdf";

            //var pdfService = new TextSharpPdfService();
            using (var pdf = CreateFromHtml(PathHtml))
            {
                using (var fs = new FileStream(PathPdf, FileMode.Create))
                {
                    pdf.CopyTo(fs);
                }
            }

            MessageBox.Show("listo");
        }

        public Stream CreateFromHtml(string html)
        {
            var stream = new MemoryStream();

            using (var doc = new Document(PageSize.A4))
            {
                using (var ms = new MemoryStream())
                {
                    using (var writer = PdfWriter.GetInstance(doc, ms))
                    {
                        writer.CloseStream = false;
                        doc.Open();

                        var tagProcessors = (DefaultTagProcessorFactory)Tags.GetHtmlTagProcessorFactory();
                        tagProcessors.RemoveProcessor(HTML.Tag.IMG);
                        tagProcessors.AddProcessor(HTML.Tag.IMG, new CustomImageTagProcessor());

                        var cssFiles = new CssFilesImpl();
                        cssFiles.Add(XMLWorkerHelper.GetInstance().GetDefaultCSS());
                        var cssResolver = new StyleAttrCSSResolver(cssFiles);

                        var charset = Encoding.UTF8;
                        var context = new HtmlPipelineContext(new CssAppliersImpl(new XMLWorkerFontProvider()));
                        context.SetAcceptUnknown(true).AutoBookmark(true).SetTagFactory(tagProcessors);
                        var htmlPipeline = new HtmlPipeline(context, new PdfWriterPipeline(doc, writer));
                        var cssPipeline = new CssResolverPipeline(cssResolver, htmlPipeline);
                        var worker = new XMLWorker(cssPipeline, true);
                        var xmlParser = new XMLParser(true, worker, charset);

                        html = File.ReadAllText(html);

                        using (var sr = new StringReader(html))
                        {
                            xmlParser.Parse(sr);
                            doc.Close();
                            ms.Position = 0;
                            ms.CopyTo(stream);
                            stream.Position = 0;
                        }
                    }
                }
            }

            return stream;
        }

        private void button1_Click(object sender, EventArgs e)
        {


            string PathRecursos = Directory.GetCurrentDirectory() + @"\..\..\reportes";
            string PathHtml = PathRecursos + @"\recibos_logo.html";
            string PathPdf = PathRecursos + @"\salida.pdf";


            using (var ms = new MemoryStream())
            {
   
                using (var doc = new Document(PageSize.A4, 40, 40, 215, 180))
                {
                
                    using (var writer = PdfWriter.GetInstance(doc, ms))
                    {
                        writer.PageEvent = new ITextEvents();
             
                        doc.Open();

                        string html = File.ReadAllText(PathHtml);

                        using (var srHtml = new StringReader(html))
                        {
                            iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, srHtml);
                        }
                        doc.Close();
                    }
                }
                Byte[] bytes = ms.ToArray();
                File.WriteAllBytes(PathPdf, bytes);
            }

            MessageBox.Show("listo");
        }

        private void btnReciboImagen_Click(object sender, EventArgs e)
        {
        //https://stackoverflow.com/questions/19389999/can-itextsharp-xmlworker-render-embedded-images
        
            //bordes
        //https://stackoverflow.com/questions/27508605/itexts-xmlworker-does-not-recognize-border-bottom-on-table-cell
            string PathRecursos = Directory.GetCurrentDirectory() + @"\..\..\reportes";
            string PathHtml = PathRecursos + @"\recibos_logo.html";
            string PathPdf = PathRecursos + @"\salida.pdf";


            using (var doc = new Document(PageSize.A4))
            {
                var writer = PdfWriter.GetInstance(doc, new FileStream(PathPdf, FileMode.Create));
                doc.Open();
                var html = File.ReadAllText(PathHtml);

                var tagProcessors = (DefaultTagProcessorFactory)Tags.GetHtmlTagProcessorFactory();
                tagProcessors.RemoveProcessor(HTML.Tag.IMG); // remove the default processor
                tagProcessors.AddProcessor(HTML.Tag.IMG, new CustomImageTagProcessor()); // use our new processor

                CssFilesImpl cssFiles = new CssFilesImpl();
                cssFiles.Add(XMLWorkerHelper.GetInstance().GetDefaultCSS());
                var cssResolver = new StyleAttrCSSResolver(cssFiles);
               // cssResolver.AddCss(@"code { padding: 2px 4px; }", "utf-8", true);
                var charset = Encoding.UTF8;
                var hpc = new HtmlPipelineContext(new CssAppliersImpl(new XMLWorkerFontProvider()));
                hpc.SetAcceptUnknown(true).AutoBookmark(true).SetTagFactory(tagProcessors); // inject the tagProcessors
                var htmlPipeline = new HtmlPipeline(hpc, new PdfWriterPipeline(doc, writer));
                var pipeline = new CssResolverPipeline(cssResolver, htmlPipeline);
                var worker = new XMLWorker(pipeline, true);
                var xmlParser = new XMLParser(true, worker, charset);
                xmlParser.Parse(new StringReader(html));
            }

            MessageBox.Show("listo");
        }

       
    }

    internal class ITextEvents : IPdfPageEvent
    {
        void IPdfPageEvent.OnChapter(PdfWriter writer, Document document, float paragraphPosition, Paragraph title)
        {

        }

        void IPdfPageEvent.OnChapterEnd(PdfWriter writer, Document document, float paragraphPosition)
        {
       
        }

        void IPdfPageEvent.OnCloseDocument(PdfWriter writer, Document document)
        {
   
        }

        void IPdfPageEvent.OnEndPage(PdfWriter writer, Document document)
        {
 
        }

        void IPdfPageEvent.OnGenericTag(PdfWriter writer, Document document, iTextSharp.text.Rectangle rect, string text)
        {
            
        }

        void IPdfPageEvent.OnOpenDocument(PdfWriter writer, Document document)
        {
            
        }

        void IPdfPageEvent.OnParagraph(PdfWriter writer, Document document, float paragraphPosition)
        {
           
        }

        void IPdfPageEvent.OnParagraphEnd(PdfWriter writer, Document document, float paragraphPosition)
        {
            
        }

        void IPdfPageEvent.OnSection(PdfWriter writer, Document document, float paragraphPosition, int depth, Paragraph title)
        {
           
        }

        void IPdfPageEvent.OnSectionEnd(PdfWriter writer, Document document, float paragraphPosition)
        {
      
        }

        void IPdfPageEvent.OnStartPage(PdfWriter writer, Document document)
        {
           
        }
    }
}
