using NPOI_excel_ClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ej2_NPOI
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
                GenerarExcelNPOI gen = new GenerarExcelNPOI();
                byte[] bytes = gen.GenerarExcelXls();

                #region 2da y última parte del formato del documento
                HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK) { Content = new ByteArrayContent(bytes, 0, bytes.Length) };
                result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = $"cenat{DateTime.Now:yymmddHHMMss}.xls" };
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.ms-excel");
                #endregion 
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
                GenerarExcelNPOI gen = new GenerarExcelNPOI();
                byte[] bytes = gen.GenerarExcelXlsx();

                #region 2da y última parte del formato del documento
                HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK) { Content = new ByteArrayContent(bytes, 0, bytes.Length) };
                result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = $"cenat{DateTime.Now:yymmddHHMMss}.xlsx" };
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
                #endregion 
            }
            catch (Exception ex)
            {
                lbError.Text = ex.Message;
            }            
        }

      
    }
}