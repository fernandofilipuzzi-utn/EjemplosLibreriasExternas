using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.tool.xml.html;
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


namespace Ej1
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
            string PathRecursos = Directory.GetCurrentDirectory() + @"\..\..\reportes";


            string PathHtml = PathRecursos + @"\recibos.html";
            string PathPdf = PathRecursos + @"\salida.pdf";
            string PathImg = PathRecursos + @"\img";

            ConvertHtmlToPdf(PathHtml, PathImg, PathPdf);

            MessageBox.Show("listo");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string PathRecursos = Directory.GetCurrentDirectory() + @"\..\..\reportes";

            string PathHtml = PathRecursos + @"\recibos_logo.html";
            string PathPdf = PathRecursos + @"\salida.pdf";
            string PathImg = PathRecursos + @"\img";

            ConvertHtmlToPdf(PathHtml, PathImg, PathPdf);

            MessageBox.Show("listo");
        }

        static void ConvertHtmlToPdf(string htmlFilePath, string PathImg, string pdfFilePath)
        {
            //https://stackoverflow.com/questions/36180131/using-itextsharp-xmlworker-to-convert-html-to-pdf-and-write-text-vertically
            //https://www.dotnettutorial.co.in/2021/02/itextsharp-html-to-pdf-convert-html-to.html
            
            Document document = new Document();

            try
            {
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(pdfFilePath, FileMode.Create));
                document.Open();

                string htmlContent = File.ReadAllText(htmlFilePath);

                /*
                string imagePath = $"\\{PathImg}\\pato.jpg"; // Reemplaza esto con la ruta de tu imagen
                byte[] imageBytes = null;

                using (MemoryStream ms = new MemoryStream())
                using (System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(100, 100))
                {
                    bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    imageBytes=ms.ToArray();
                }

                string base64String = Convert.ToBase64String(imageBytes);
                string logo = $"data:image/jpg;base64,{base64String}";
                htmlContent = htmlContent.Replace("$logo$", logo);
                */
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
                MessageBox.Show("Error");
            }
        }

       
    }
}
