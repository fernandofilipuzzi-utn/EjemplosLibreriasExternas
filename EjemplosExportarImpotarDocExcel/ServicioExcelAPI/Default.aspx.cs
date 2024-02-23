using ServicioAPI.Client.Services.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Web.Http.Results;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServicioAPI.Services;
using System.IO;
using System.Web.Services.Description;

namespace ServicioAPI
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
                
        protected void btnExportacionCasoParticular_Click(object sender, EventArgs e)
        {
            //ejemplo de un caso particular, donde el excel a generar es complejo y no se 
            //puede enmarcar en un simple datatable
            try
            {
                EjemploServicioCasoParticular servicio = new EjemploServicioCasoParticular();

                byte[] bytes = servicio.ExportarAExcel(ImportacionExcelUtils.TipoFormato.XLS);
                string mimeType = ImportacionExcelUtils.GetMimeType(ImportacionExcelUtils.TipoFormato.XLS);

                #region generando el response con el fichero
                var fileName = "ejemplo.xls";
                HttpResponse response = HttpContext.Current.Response;
                response.Clear();
                response.ContentType = mimeType;
                response.AddHeader("Content-Disposition", $"attachment;filename=\"{fileName}\"");

                var memoryStream = new MemoryStream();
                memoryStream.Write(bytes, 0, bytes.Length);
                memoryStream.Seek(0, SeekOrigin.Begin);
                memoryStream.CopyTo(Response.OutputStream);
                response.End();
                #endregion
            }
            catch (Exception ex)
            {
                ((SiteMaster)this.Master).ShowMessage(ex.Message + ex.StackTrace.ToString(), "Mensaje");

            }
        }

    }
}