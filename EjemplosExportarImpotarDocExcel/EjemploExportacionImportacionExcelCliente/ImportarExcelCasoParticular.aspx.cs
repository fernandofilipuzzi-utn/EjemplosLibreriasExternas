using EjemploExportacionImportacionExcelCliente;
using ServicioAPI.Client.Services.Services;
using ServicioEncuestasAPIClient.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServicioEncuestasAPIClient
{
    public partial class ImportarExcelCasoParticular : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnDescargarEjemploExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = Server.MapPath("~/DescargaEjemplos/CasoParticular.xlsx");

                if (File.Exists(filePath))
                {
                    byte[] fileBytes = File.ReadAllBytes(filePath);

                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.Buffer = true;
                    HttpContext.Current.Response.ContentType = ImportacionExcelUtils.GetMimeType(ImportacionExcelUtils.TipoFormato.XLSX); ;
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=ejmplo.xlsx");
                    HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    HttpContext.Current.Response.BinaryWrite(fileBytes);
                    HttpContext.Current.Response.End();
                }
                else
                {
                    ((SiteMaster)this.Master).ShowMessage("El archivo no existe", "Mensaje");
                }
            }
            catch (Exception ex)
            {
                ((SiteMaster)this.Master).ShowMessage(ex.Message + ex.StackTrace.ToString(), "Mensaje");
            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            if (fuFicheroExcel.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(fuFicheroExcel.FileName);
                    string pathUpload = Path.Combine(Server.MapPath("/Uploads/") + filename);
                    fuFicheroExcel.SaveAs(pathUpload);

                    if (File.Exists(pathUpload))
                    {
                        EjemploServicioCasoParticular oService = new EjemploServicioCasoParticular();

                        using (FileStream fileStream = File.OpenRead(pathUpload))
                        {
                            //libreria para manejar las peticiones a la api que resuelve esto
                            DataSet dt = oService.ImportarExcelResumenInsumos(fileStream);

                            ListView1.DataSource = dt.Tables["Resumenes"];
                            ListView1.DataBind();
                        }

                        // Response.SuppressContent = true;  // Prevents the HTTP headers from being sent to the client.
                        // HttpContext.Current.ApplicationInstance.CompleteRequest();
                    }
                    else
                    {
                        throw new Exception("Error en el servidor. No se encontró el fichero!.");
                    }
                }
                catch (Exception ex)
                {
                    string mensaje = $"<p>{ex.Message}</p><p>{ex.StackTrace.ToString()}</p>";
                    if (ex.InnerException != null)
                        mensaje += $"<p>{ex.InnerException.Message}</p><p>{ex.InnerException.StackTrace.ToString()}</p>";
                    ((SiteMaster)this.Master).ShowMessage(mensaje, "Error en la solicitud de importación");
                }
            }
        }
    }
}