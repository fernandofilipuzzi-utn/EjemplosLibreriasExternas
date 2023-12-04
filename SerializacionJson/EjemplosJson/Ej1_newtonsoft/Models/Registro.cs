using Ej1_newtonsoft.CustomJsonConverter;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej1_newtonsoft.Models
{
    

    public class Registro
    {
        [JsonProperty("valorEntero")]
        public int ValorEntero { get; set; }

        [JsonProperty("valorDecimal")]
        [JsonConverter(typeof(DoubleCustomConverter))]
        public double ValorDecimal { get; set; }

        //Total de Importe Pagado para la Moneda, formato:14 enteros 2 decimales
        [JsonProperty("valorDecimal14F2")]
        [JsonConverter(typeof(DoubleCustomConverter))]
        public double ValorDecimal14F2 { get; set; }

        [JsonIgnore]
        public DateTime Fecha { get; set; }

        [JsonProperty("fechaCustom")]
        [JsonConverter(typeof(DateTimeParametrizedCustomDateTimeConverter), "yyyy-MM-dd")]
        public DateTime FechaCustom { get { return Fecha; } set { Fecha=value; } }

        [JsonIgnore]
        public DateTime FechaHora { get; set; }

        [JsonProperty("fechaHoraCustom")]
        [JsonConverter(typeof(DateTimeParametrizedCustomDateTimeConverter), "yyyy-MM-ddTHH:mm:ss")]
        public DateTime FechaHoraCustom { get { return FechaHora; } set { FechaHora = value; } }

        /* forma antigua
        [JsonProperty("fechaFormatoYYYYMMDD")]
        public string FechaFormatoYYYYMMDD
        {
            get 
            {
                return Fecha.ToString("yyyy-MM-dd");
            }
            set 
            {
                string fechaString = value;

                if (DateTime.TryParseExact(fechaString, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaConvertida))
                {
                    Fecha = fechaConvertida;
                }
            }
        }

        [JsonProperty("fechaFormatoYYYYMMDDHHMMSS")]
        public string FechaFormatoYYYYMMDDHHMMSS
        {
            get
            {
                return Fecha.ToString("yyyy-MM-ddThh-mm-ss");
            }
            set
            {
                string fechaString = value;

                if (DateTime.TryParseExact(fechaString, "yyyy-MM-ddThh-mm-ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaConvertida))
                {
                    Fecha = fechaConvertida;
                }
            }
        }
        */

        public override string ToString()
        {
            return $"ValorEntero :{ValorEntero}\nValorDecimal:{ValorDecimal}\nValorDecimal14F2:{ValorDecimal14F2}\n" +
                $"Fecha:{Fecha.ToString()}\nFechaHora:{FechaHora.ToString()}";
        }
    }
}
