using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ServicioAPI.Client.Services.Models
{
    public class ExportarAExcelRequest
    {
        [JsonProperty("datasource", NullValueHandling = NullValueHandling.Ignore)]
        public DataTable DataSource { get; set; }
    }
}