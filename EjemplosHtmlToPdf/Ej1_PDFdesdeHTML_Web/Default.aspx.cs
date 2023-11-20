using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Ej1_QR_Web
{
    public partial class _Default : Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
           
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            string PathHtmlOrigen = "https://fernandofilipuzzi-utn.github.io/EjemplosLibreriasExternas/ej1_tarjetas/tarjeta.html";
            itext7.pdfhtmlClassLib.GenerarPDF gen = new itext7.pdfhtmlClassLib.GenerarPDF();
            byte[] bytes=gen.GenerarPDFFromHTML(PathHtmlOrigen);

            // Configurar la respuesta HTTP para devolver el archivo PDF
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=archivo.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(bytes);
            Response.End();
        }
    }
}