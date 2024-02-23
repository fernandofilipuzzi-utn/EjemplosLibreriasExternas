using ServicioAPI.Client.Services.Models;
using ServicioAPI.Client.Services.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServicioAPI
{
    public partial class ExportarAExcelPorAPI_ReturnFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Generar un fichero excel(XLSX) desde un datatable por medio de la API Genérica
        ///
        protected void btnExportarFichero_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = EmulandoConsulta().Tables[0];

                #region hace la llamada a la api
                ExcelDTOClientService oService = new ExcelDTOClientService();
                ExportarAExcelRequest request = new ExportarAExcelRequest { DataSource = dt };
                DTO_Respuesta respuesta = oService.ExportarAExcel(request);
                #endregion
                //
                #region genera el response con fichero
                oService.DTORespuestaAStream(respuesta, Response);
                Response.SuppressContent = true;  // Prevents the HTTP headers from being sent to the client.
                HttpContext.Current.ApplicationInstance.CompleteRequest();
                #endregion
            }
            catch (Exception ex)
            {
                string errores = HttpUtility.HtmlEncode($"{ex.Message}|{ex.StackTrace}");
                if (ex.InnerException != null)
                    errores += HttpUtility.HtmlEncode($"{ex.InnerException.Message}|{ex.InnerException.StackTrace}");

                ((SiteMaster)this.Master).ShowMessage("Error", errores);
            }
        }
             
        private DataSet EmulandoConsulta()
        {
            DataSet dataSet = new DataSet();
            //
            DataTable dt = new DataTable();
            dataSet.Tables.Add(dt);
            //
            dt.Columns.Add("Texto", typeof(string));
            dt.Columns.Add("Entero", typeof(int));
            dt.Columns.Add("Decimal", typeof(double));
            dt.Columns.Add("Moneda", typeof(double));
            dt.Columns.Add("Fecha", typeof(DateTime));
            dt.Columns.Add("Hora", typeof(DateTime));

            #region agregando fila 1
            DataRow fila = dt.NewRow(); fila["Texto"] = "contenido 1"; fila["Entero"] = 3;
            fila["Decimal"] = 3000d; fila["Moneda"] = 300d;
            fila["Fecha"] = DateTime.Now; fila["Hora"] = DateTime.Now;
            dt.Rows.Add(fila);
            #endregion

            #region agregando fila 2
            fila = dt.NewRow(); fila["Texto"] = "contenido 2"; fila["Entero"] = 300;
            fila["Decimal"] = 3023.20d; fila["Moneda"] = 300.23d;
            fila["Fecha"] = DateTime.Now; fila["Hora"] = DateTime.Now;
            dt.Rows.Add(fila);
            #endregion

            return dataSet;
        }
    }
}