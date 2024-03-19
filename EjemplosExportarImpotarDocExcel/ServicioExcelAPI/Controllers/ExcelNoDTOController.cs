using ServicioAPI.Client.Services.Services;
using ServicioAPI.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace ServicioAPI.Controllers
{

    /// <summary>
    /// Recibo/Envío el fichero como stream 
    /// Serializo/Deserializo directamente el DataTable
    /// </summary>
    [RoutePrefix("api/ExcelFileStream")]
    public class ExcelNoDTOController : ApiController
    {
        [HttpPost]
        [Route("ExportarAExcel")]
        public HttpResponseMessage PostExportarAExcel([FromBody] DataTable dt)
        {
            HttpResponseMessage result = null;
            try
            {
                if (dt == null)
                {
                    var badRequestResponse = new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent("Los parámetros no son adecuados.")
                    };

                    return badRequestResponse;
                }

                #region generacion excel
                ProcesarExcel generador = new ProcesarExcel();

                byte[] bytes = generador.ExportarDataTableToExcel(dt, ImportacionExcelUtils.TipoFormato.XLSX);
                string mimeType = ImportacionExcelUtils.GetMimeType(ImportacionExcelUtils.TipoFormato.XLSX);

                result = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ByteArrayContent(bytes, 0, bytes.Length)
                };
                result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = $"cenat{DateTime.Now:yymmddHHMMss}.xls"
                };
                result.Content.Headers.ContentType = new MediaTypeHeaderValue(mimeType);
                #endregion
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
                result = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(html)
                };
                result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = $"error.html" };
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            }
            return result;
        }

        [HttpPost]
        [Route("ImportarExcelToDataSet")]
        public IHttpActionResult PostImportarExcel()
        {
            DataSet ds = new DataSet();
            ds.Tables.Add(new DataTable("Resultado"));

            if (!Request.Content.IsMimeMultipartContent())
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

            try
            {
                var provider = new MultipartMemoryStreamProvider();
                Request.Content.ReadAsMultipartAsync(provider).Wait();
                var archivo = provider.Contents.FirstOrDefault();
                var archivoStream = archivo.ReadAsStreamAsync().Result;

                /* si quiero guardarlo en el server
                string appPath = System.Web.Hosting.HostingEnvironment.MapPath("~/");
                var filePath = Path.Combine(appPath, "UploadsServer", "Ejemplo.xlsx");

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    archivoStream.CopyTo(fileStream);
                }*/

                #region generacion excel
                ProcesarExcel generador = new ProcesarExcel();
                ds = generador.ImportarExcelToDataSet(archivoStream);
                #endregion
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(ds);
        }
    }
}
