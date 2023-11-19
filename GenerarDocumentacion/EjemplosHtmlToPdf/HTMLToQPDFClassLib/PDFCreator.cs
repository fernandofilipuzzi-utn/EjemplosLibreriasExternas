using QuestPDF.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLToQPDFClassLib
{
    class PDFCreator
    {
        public void GenerarPDFFromHTML(string PathHtml, string PathPdf)
        {
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Content().Column(col =>
                    {
                        col.Item().HTML(handler =>
                        {
                            handler.SetHtml(PathHtml);
                        });
                    });
                });
            }).GeneratePdf(PathPdf);
        }
    }
}
