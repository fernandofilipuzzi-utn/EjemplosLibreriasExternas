using NPOI_excel_ClassLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ej2_NPOI_Web
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnXLS_Click(object sender, EventArgs e)
        {
            try
            {
                GenerarExcelNPOI generador = new GenerarExcelNPOI();

                byte[] bytes = generador.GenerarExcel(GenerarExcelNPOI.TipoFormato.XLS);
                string mimeType = generador.GetMimeType(GenerarExcelNPOI.TipoFormato.XLS);

                var fileName = "ejemplo.xls";
                HttpResponse response = HttpContext.Current.Response;
                response.Clear();
                response.ContentType = mimeType;
                response.AddHeader("Content-Disposition", $"attachment;filename=\"{fileName}\"");

                var memoryStream = new MemoryStream();
                memoryStream.Write(bytes,0,bytes.Length);
                memoryStream.Seek(0, SeekOrigin.Begin);
                memoryStream.CopyTo(Response.OutputStream);
                response.End();
            }
            catch (Exception ex)
            {
                lbError.Text = ex.Message;
            }
        }

        protected void btnXLSX_Click(object sender, EventArgs e)
        {
            try
            {
                GenerarExcelNPOI generador = new GenerarExcelNPOI();
                byte[] bytes = generador.GenerarExcel(GenerarExcelNPOI.TipoFormato.XLSX);
                string mimeType = generador.GetMimeType(GenerarExcelNPOI.TipoFormato.XLSX);

                var fileName = "ejemplo.xlsx";
                HttpResponse response = HttpContext.Current.Response;
                response.Clear();
                response.ContentType = mimeType;
                response.AddHeader("Content-Disposition", $"attachment;filename=\"{fileName}\"");

                var memoryStream = new MemoryStream();
                memoryStream.Write(bytes, 0, bytes.Length);
                memoryStream.Seek(0, SeekOrigin.Begin);
                memoryStream.CopyTo(Response.OutputStream);
                response.End();
            }
            catch (Exception ex)
            {
                lbError.Text = ex.Message;
            }
        }
    }
}