using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioAPI.Client.Services.Models
{
    public class DTO_Respuesta
    {
        [JsonProperty("codigo", NullValueHandling = NullValueHandling.Ignore)]
        public int Codigo { get; set; }

        [JsonProperty("mensaje", NullValueHandling = NullValueHandling.Ignore)]
        public string Mensaje { get; set; }

        [JsonProperty("datos", NullValueHandling = NullValueHandling.Ignore)]
        public object Datos { get; set; }
    }
}