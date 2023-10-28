using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.tool.xml.html;
using iTextSharp.tool.xml.html.table;
using iTextSharp.tool.xml.parser;
using iTextSharp.tool.xml.pipeline.css;
using iTextSharp.tool.xml.pipeline.end;
using iTextSharp.tool.xml.pipeline.html;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej3_iTextSharp
{
    static class PdfCreator
    {
        public static string ConvertHtmlToPdf(string htmlContent, string fileNameWithPath, string cssContent = "")
        {
            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                using (var document = new Document())
                {
                    var writer = PdfWriter.GetInstance(document, stream);
                    document.Open();

                    var tagProcessorFactory = Tags.GetHtmlTagProcessorFactory();
                    tagProcessorFactory.AddProcessor(new TableData(), new string[] { HTML.Tag.TD });
                    var htmlPipelineContext = new HtmlPipelineContext(null);
                    htmlPipelineContext.SetTagFactory(tagProcessorFactory);

                    var pdfWriterPipeline = new PdfWriterPipeline(document, writer);
                    var htmlPipeline = new HtmlPipeline(htmlPipelineContext, pdfWriterPipeline);

                    var cssResolver = XMLWorkerHelper.GetInstance().GetDefaultCssResolver(true);
                    cssResolver.AddCss(cssContent, "utf-8", true);
                    var cssResolverPipeline = new CssResolverPipeline( cssResolver, htmlPipeline);

                    var worker = new XMLWorker(cssResolverPipeline, true);
                    var parser = new XMLParser(worker);
                    using (var stringReader = new StringReader(htmlContent))
                    {
                        parser.Parse(stringReader);
                    }
                }
            }
            return fileNameWithPath;
        }
    }
}
