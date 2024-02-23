﻿using Microsoft.Web.Administration;
using Newtonsoft.Json;
using ServicioAPI.Client.Services.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ServicioAPI.Client.Services.Services
{
    public class ExcelFileStreamClientService
    {
        public static void AjustarLimiteRespuesta(string nombreSitio, long nuevoLimite)
        {
            using (ServerManager serverManager = new ServerManager())
            {
                Microsoft.Web.Administration.Site sitio = serverManager.Sites[nombreSitio];

                if (sitio != null)
                {
                    Configuration configuracionSitio = serverManager.GetWebConfiguration(nombreSitio);
                    ConfigurationSection requestFilteringSection = configuracionSitio.GetSection("system.webServer/security/requestFiltering");

                    ConfigurationElement requestLimitsElement = requestFilteringSection.GetCollection("requestLimits").FirstOrDefault();
                    if (requestLimitsElement != null)
                    {
                        requestLimitsElement["maxAllowedContentLength"] = nuevoLimite;
                    }

                    serverManager.CommitChanges();
                }
            }
        }

        //llamada al servicio exportardor a excel
        public void ExportarAExcel(DataTable dt, HttpResponse @out)
        {
            string url = "http://localhost:7777/api/ExcelFileStream/ExportarAExcel";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var requestContent = JsonConvert.SerializeObject(dt);
                    int tamanoBytes = Encoding.UTF8.GetBytes(requestContent).Length;

                    var request = new HttpRequestMessage(HttpMethod.Post, url)
                    {
                        Content = new StringContent(requestContent, Encoding.UTF8, "application/json")
                    };
                    request.Headers.Add("Accept", "application/json;utf-8 ");

                    HttpResponseMessage response = client.SendAsync(request).Result;

                    byte[] fileContents = response.Content.ReadAsByteArrayAsync().Result;

                    if (response.IsSuccessStatusCode)
                    {
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
                        @out.Clear();
                        @out.Buffer = true;
                        @out.ContentType = "text/html";
                        @out.BinaryWrite(fileContents);
                        @out.Flush();
                        @out.Close();
                    }
                }
                // Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //llamada al servicio importador
        public DataSet ImportarExcel(string pathUpload)
        {
            #region inicialización de un dataset vacio
            DTO_Respuesta respuesta = new DTO_Respuesta();
            DataSet dataSet = new DataSet();
            respuesta.Datos = dataSet;
            DataTable dt = new DataTable();
            dataSet.Tables.Add(dt);
            #endregion

            string url = "http://localhost:7777/api/ExcelFileStream/ImportarExcelToDataSet";
            try
            {
                using (HttpClient client = new HttpClient())
                using (FileStream fileStream = File.OpenRead(pathUpload))
                {
                    using (var formData = new MultipartFormDataContent())
                    {
                        formData.Add(new StreamContent(fileStream), "archivo", Path.GetFileName(pathUpload));
                        var request = new HttpRequestMessage(HttpMethod.Post, url)
                        {
                            Content = formData
                        };
                        HttpResponseMessage response = client.SendAsync(request).Result;

                        string dataJson = response.Content.ReadAsStringAsync().Result;
                        if (response.IsSuccessStatusCode)
                        {
                            dataSet = JsonConvert.DeserializeObject<DataSet>(dataJson);
                        }
                        else
                        {
                            throw new Exception("error al enviar el fichero");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dataSet;
        }
    }
}
