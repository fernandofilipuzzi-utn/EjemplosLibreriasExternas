using Newtonsoft.Json;
using ServicioAPI.Client.Services.Models;
using ServicioAPI.Client.Services.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServicioAPI
{
    public partial class ImportarExcelPorAPI_InputFile_NoDTO : System.Web.UI.Page
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
                    string filename = Path.GetFileName(fuFicheroExcel.FileName);
                    string pathUpload = Path.Combine(Server.MapPath("/Uploads/") + filename);
                    fuFicheroExcel.SaveAs(pathUpload);

                    if (File.Exists(pathUpload))
                    {
                        ExcelFileStreamClientService oService = new ExcelFileStreamClientService();

                        //libreria soporte para manejar las peticiones a la api que resuelve esto
                        DataSet dt = oService.ImportarExcel(pathUpload);
                        ListView1.DataSource = dt.Tables[0];
                        ListView1.DataBind();
                    }
                    else
                    {
                        throw new Exception("Error en el servidor. No se encontró el fichero!.");
                    }
                }
                catch (Exception ex)
                {
                    string errores = HttpUtility.HtmlEncode($"{ex.Message}|{ex.StackTrace}");
                    if (ex.InnerException != null)
                        errores += HttpUtility.HtmlEncode($"{ex.InnerException.Message}|{ex.InnerException.StackTrace}");

                    ((SiteMaster)this.Master).ShowMessage("Error", errores);
                }
            }
        }
    }
}