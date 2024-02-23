using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using ServicioAPI.Client.Services.Models;
using ServicioAPI.Client.Services.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServicioAPI
{
    public partial class ImportarExcelPorAPI_InputFile_DTO : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            if (fuFicheroExcel.HasFile)
            {
                try
                {
                    #region sube el fichero 
                    string filename = Path.GetFileName(fuFicheroExcel.FileName);
                    string pathUpload = Path.Combine(Server.MapPath("/Uploads/") + filename);
                    fuFicheroExcel.SaveAs(pathUpload);
                    #endregion

                    if (File.Exists(pathUpload))
                    {
                        ExcelDTOClientService oService = new ExcelDTOClientService();

                        #region delego en la libreria la llamada a la API pero se puede insertar esas subrutinas aquí
                        DTO_Respuesta respuesta = oService.ImportarExcelAtravesAPI(pathUpload);
                        //DataSet dt = respuesta.Datos as DataSet;
                        DataSet dt = JsonConvert.DeserializeObject<DataSet>(respuesta.Datos as string);
                        #endregion

                        #region este listview solo se ajusta al ejemplo dado en la exportación a modo ilustrativo
                        ListView1.DataSource = dt.Tables[0];
                        ListView1.DataBind();
                        #endregion
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