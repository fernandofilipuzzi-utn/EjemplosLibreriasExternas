
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

using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.tool.xml.css;
using iTextSharp.tool.xml.parser;
using iTextSharp.tool.xml.pipeline.css;
using iTextSharp.tool.xml.pipeline.end;
using iTextSharp.tool.xml.pipeline.html;

namespace Ej1_plan_de_pagos
{
    public partial class FormPrincipal : Form
    {

    

        public FormPrincipal()
        {
            InitializeComponent();
        }
                
        private void FormPrincipal_Load(object sender, EventArgs e)
        {            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string PathRecursos = Directory.GetCurrentDirectory()+ @"\..\..\reportes";

            string PathHtml = PathRecursos + @"\recibos.html";
            string PathPdf = PathRecursos + @"\recibos.pdf";

            string html = File.ReadAllText(PathHtml);
            ConvertHtmlToPdf(PathHtml, PathPdf);
        }

        static void ConvertHtmlToPdf(string htmlFilePath, string pdfFilePath)
        {
            //https://stackoverflow.com/questions/36180131/using-itextsharp-xmlworker-to-convert-html-to-pdf-and-write-text-vertically

            Document document = new Document();

            try
            {
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(pdfFilePath, FileMode.Create));
                document.Open();

                string htmlContent = File.ReadAllText(htmlFilePath);
                
                //StringReader stringReader = new StringReader(htmlContent);
              
                document.SetPageSize(PageSize.A4);
                document.SetMargins(36, 36, 36, 36);


                XMLWorkerHelper xml = XMLWorkerHelper.GetInstance();


                var stream = new MemoryStream();
                var w = new StreamWriter(stream);
                w.Write(htmlContent);
                w.Flush();
                stream.Position = 0;

                xml.ParseXHtml(writer, document, stream, System.Text.Encoding.UTF8);
              

                document.Close();
            }
            catch (Exception ex)
            {
               
            }
        }
    }
}
