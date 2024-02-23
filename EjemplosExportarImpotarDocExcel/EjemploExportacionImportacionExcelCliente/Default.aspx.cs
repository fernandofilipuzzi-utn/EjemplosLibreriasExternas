using Newtonsoft.Json;
using ServicioAPI.Client.Services.Models;
using ServicioAPI.Client.Services.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EjemploExportacionImportacionExcelCliente
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }


        /// <summary>
        /// Este Caso le paso un dataTable y me devuelve un fichero
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnExcel1_Click(object sender, EventArgs e)
        {
            string url = "http://localhost:5002/api/Excel/GetExcel";
            try
            {
                #region ejemplo datatable
                DataSet dataSet = new DataSet();
                DataTable dt = new DataTable();
                dataSet.Tables.Add(dt);
                dt.Columns.Add("A", typeof(string));
                dt.Columns.Add("B", typeof(int));
                dt.Columns.Add("C", typeof(DateTime));

                DataRow fila = dt.NewRow();
                fila["A"] = "contenido 1"; fila["B"] = 3; fila["C"] = DateTime.Now;
                dt.Rows.Add(fila);

                fila = dt.NewRow();
                fila["A"] = "contenido 2"; fila["B"] = 5; fila["C"] = DateTime.Now;
                dt.Rows.Add(fila);
                #endregion 

                /*hace la llamada a la api*/
                ExcelClientService oService = new ExcelClientService();
                ExportarAExcelRequest request = new ExportarAExcelRequest { DataSource=dt};
                DTO_Respuesta respuesta= oService.ExportarAExcel(request);
                //
                //le paso la respuesta así me inserta el fichero en el response.
                oService.DTORespuestaAStream(respuesta,Response);

                Response.SuppressContent = true;  // Prevents the HTTP headers from being sent to the client.
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                string errores = HttpUtility.HtmlEncode($"{ex.Message}|{ex.StackTrace}");
                if (ex.InnerException != null)
                    errores += HttpUtility.HtmlEncode($"{ex.InnerException.Message}|{ex.InnerException.StackTrace}");

                ((SiteMaster)this.Master).ShowMessage("Error", errores);
            }
        }

        /*
         * esta forma solo anda desde el depurador, algo pasa en el IIS
         **/
        protected void btnExcel2_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes("kk");
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "text/html";
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.SuppressContent = true;
                HttpContext.Current.ApplicationInstance.CompleteRequest();

                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                string errores = HttpUtility.HtmlEncode($"{ex.Message}|{ex.StackTrace}");
                if (ex.InnerException != null)
                    errores += HttpUtility.HtmlEncode($"{ex.InnerException.Message}|{ex.InnerException.StackTrace}");

                ((SiteMaster)this.Master).ShowMessage("Error", errores);
            }
        }

        protected void btnImportar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ImportarExcelAtravesAPI.aspx");
        }
    }
}