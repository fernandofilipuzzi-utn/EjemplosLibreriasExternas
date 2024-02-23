using Newtonsoft.Json;
using NPOI.HSSF.UserModel;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using NPOI.XSSF.Streaming;
using NPOI.XSSF.UserModel;
using Org.BouncyCastle.Utilities;
using ServicioAPI.Client.Services.Models;
using ServicioAPI.Client.Services.Services;
using ServicioAPI.Client.ServicesI.Models;
using ServicioAPI.Models;
using ServicioAPI.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ServicioAPI.Controllers
{
    [RoutePrefix("api/ExcelDTO")]
    public class ExcelDTOController : ApiController
    {
        [HttpPost]
        [Route("ExportarAExcel")]
        public DTO_Respuesta PostExportarAExcel([FromBody] ExportarAExcelRequest request)
        {
            DTO_Respuesta respuesta =null;
            try
            {
                #region verificando argumentos
                if (request == null || request.DataSource == null)
                {
                    respuesta = new DTO_Respuesta { Codigo = 400, Mensaje="Faltan parametros" };
                }
                #endregion 

                #region generacion excel
                ProcesarExcel generador = new ProcesarExcel();

                byte[] bytes = generador.ExportarDataTableToExcel(request.DataSource, ImportacionExcelUtils.TipoFormato.XLSX);
                string mimeType = ImportacionExcelUtils.GetMimeType(ImportacionExcelUtils.TipoFormato.XLSX);

                //esto es así para poder serializar un array de bytes,.
                string datosBase64 = Convert.ToBase64String(bytes);
                

                respuesta = new DTO_Respuesta { Codigo=200, Datos = datosBase64 };
                #endregion
            }
            catch (Exception ex)
            {
                #region pagina error
                string mensaje= $"{ex.Message} | {ex.StackTrace} ";

                if (ex.InnerException != null)
                {
                    mensaje += $"|{ex.InnerException.Message}|{ex.InnerException.Message}";
                }
                respuesta = new DTO_Respuesta { Codigo = 500, Datos = mensaje };
                #endregion
            }
            return respuesta;
        }

        [HttpPost]
        [Route("ImportarExcelToDataSet")]
        public DTO_Respuesta PostImportarExcel(ImportarExcelRequest request)
        {
            DTO_Respuesta respuesta = null;

            DataSet ds = new DataSet();
            ds.Tables.Add(new DataTable("Resultado"));

            #region verificando argumentos
            if (request == null || request.FileContenido == null)
            {
                respuesta = new DTO_Respuesta { Codigo = 400, Mensaje = "Faltan parametros" };
            }
            #endregion

            try
            {
                using(var memoryStream=new  MemoryStream(request.GetFileContenido()))
                {
                    #region importar excel desde un memoryStream
                    ProcesarExcel generador = new ProcesarExcel();
                    ds = generador.ImportarExcelToDataSet(memoryStream);
                    string json = JsonConvert.SerializeObject(ds, Formatting.Indented);
                    respuesta = new DTO_Respuesta { Codigo = 200, Datos = json };
                    #endregion
                }
            }
            catch (Exception ex)
            {
                #region pagina error
                string mensaje = $"{ex.Message} | {ex.StackTrace} ";

                if (ex.InnerException != null)
                {
                    mensaje += $"|{ex.InnerException.Message}|{ex.InnerException.Message}";
                }
                respuesta = new DTO_Respuesta { Codigo = 500, Datos = mensaje };
                #endregion
            }

            return respuesta;
        }        
    }
}
