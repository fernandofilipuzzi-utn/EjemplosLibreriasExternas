using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioAPI.Client.ServicesI.Models
{
    public class ImportarExcelRequest
    {
        [JsonProperty("contenido", NullValueHandling = NullValueHandling.Ignore)]
        public string FileContenido { get; set; }

        public byte[] GetFileContenido()
        {
            string datosBase64 = FileContenido;
            byte[] fileContents = Convert.FromBase64String(datosBase64);
            return fileContents;
        }
    }
}