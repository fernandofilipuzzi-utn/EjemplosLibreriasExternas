﻿using ServicioAPI.Client.Services.Services;
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

        protected void btnExcelDesdeUnDataTable_Click(object sender, EventArgs e)
        {
            //Generar un fichero excel(XLSX) por medio de un datatable

            //acces remoto
            //string url = @"http://localhost:7777/api/Excel/GetExcel";
            //acceso local
            string url = @"/api/Excel/GetExcel";

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

                /*lib soporte creada para delegar las llamadas a las apis. para usar en otros proyectos*/
                ExcelClientService oService = new ExcelClientService();

                oService.ExportarAExcel(dt, Response);

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

        protected void btnImportar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ImportarExcelToDataSet.aspx");
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