using Microsoft.Web.Administration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ServicioAPI.Client.Services.Models;
using ServicioAPI.Client.ServicesI.Models;
using System.Web.Routing;
using System.Security.Policy;

namespace ServicioAPI.Client.Services.Services
{
    public class ExcelDTOClientService
    {        
        //llamada al servicio exportardor a excel
        public DTO_Respuesta ExportarAExcel(ExportarAExcelRequest request)
        {
            DTO_Respuesta respuesta = null;

            string url = "http://localhost:7777/api/ExcelDTO/ExportarAExcel";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    #region prepara el body - serializa el datatable 
                    var requestContent = JsonConvert.SerializeObject(request);
                    int tamanoBytes = Encoding.UTF8.GetBytes(requestContent).Length;

                    var requestPost = new HttpRequestMessage(HttpMethod.Post, url)
                    {
                        Content = new StringContent(requestContent, Encoding.UTF8, "application/json")
                    };
                    requestPost.Headers.Add("Accept", "application/json;utf-8 ");
                    #endregion

                    var response = client.SendAsync(requestPost).Result;

                    #region procesa la respuesta
                    if (response.IsSuccessStatusCode)
                    {
                        string json  = response.Content.ReadAsStringAsync().Result;
                        respuesta = JsonConvert.DeserializeObject<DTO_Respuesta>(json);
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respuesta;
        }
                      
        public DTO_Respuesta ImportarExcelAtravesAPI(string pathUpload)
        {
            #region inicialización de un dataset vacio
            DTO_Respuesta respuesta=new DTO_Respuesta();
            DataSet dataSet = new DataSet();
            respuesta.Datos = dataSet;
            DataTable dt = new DataTable();
            dataSet.Tables.Add(dt);
            #endregion

            string url = "http://localhost:7777/api/ExcelDTO/ImportarExcelToDataSet";
            try
            {
                using (HttpClient client = new HttpClient())
                using (FileStream fileStream = File.OpenRead(pathUpload))
                {
                    #region preparando el DTO
                    //si envia un fichero serializado hay que codearlo a base 64
                    byte[] bytes = new byte[fileStream.Length];
                    fileStream.Read(bytes, 0, bytes.Length);
                    string datosBase64 = Convert.ToBase64String(bytes);
                    ImportarExcelRequest importarExcelRequest = new ImportarExcelRequest()
                    {
                        FileContenido = datosBase64
                    };
                    #endregion

                    var requestContent = JsonConvert.SerializeObject(importarExcelRequest);
                    var request = new HttpRequestMessage(HttpMethod.Post, url)
                    {
                        Content = new StringContent(requestContent, Encoding.UTF8, "application/json")
                    };
                    HttpResponseMessage response = client.SendAsync(request).Result;

                    string dataJson = response.Content.ReadAsStringAsync().Result;
                    if (response.IsSuccessStatusCode)
                    {
                        respuesta = JsonConvert.DeserializeObject<DTO_Respuesta>(dataJson);
                       // respuesta.Datos = JsonConvert.DeserializeObject<DataSet>(respuesta.Datos as string);
                    }
                    else
                    {
                        throw new Exception("error al enviar el fichero");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return respuesta;
        }

        #region metodos de utilería
        public void DTORespuestaAStream(DTO_Respuesta respuesta, HttpResponse @out)
        {
            if (respuesta!=null && respuesta.Codigo == 200)
            {
                //byte[] fileContents = Encoding.UTF8.GetBytes(respuesta.Datos as string);
                string datosBase64 = respuesta.Datos as string;
                byte[] fileContents = Convert.FromBase64String(datosBase64);

                @out.Clear();
                @out.Buffer = true;
                @out.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                @out.AddHeader("Content-Disposition", "attachment; filename=Exportacion.xlsx");
                @out.BinaryWrite(fileContents);
                @out.Flush();
                @out.Close();
                //Response.End();//con eso me da subproceso anulado
            }
            else
            {
                byte[] fileContents = Encoding.UTF8.GetBytes(respuesta.Datos as string);

                @out.Clear();
                @out.Buffer = true;
                @out.ContentType = "text/html";
                @out.BinaryWrite(fileContents);
                @out.Flush();
                @out.Close();
            }
        }
        #endregion
    }
}
