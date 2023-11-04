using NPOI_excel_ClassLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Ej3_NPOI_API.Controllers
{
    public class NPOIExportacionExcelController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage GetExcel(string toke)
        {
            HttpResponseMessage result = null ;
            try
            {
                GenerarExcelNPOI generador = new GenerarExcelNPOI();

                byte[] bytes = generador.GenerarExcel(GenerarExcelNPOI.TipoFormato.XLS);
                string mimeType = generador.GetMimeType(GenerarExcelNPOI.TipoFormato.XLS);

                result = new HttpResponseMessage(HttpStatusCode.OK) { Content = new ByteArrayContent(bytes, 0, bytes.Length) };
                result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = $"cenat{DateTime.Now:yymmddHHMMss}.xls" };
                result.Content.Headers.ContentType = new MediaTypeHeaderValue(mimeType);
            }
            catch (Exception ex)
            {
                string html = "";
                html = $"<h4>{ex.Message}</h4>" +
                        $" <p>{ex.StackTrace}</p>";
                if (ex.InnerException != null)
                {
                    html += $"<h4>{ex.InnerException.Message}</h4>" +
                             $"<p>{ex.InnerException.Message}</p>";
                }
                result = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(html) };
                result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = $"cenat{DateTime.Now:yymmddHHMMss}.xls" };
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            }
            finally
            { 
            }
            return result;
        }
    }
}
