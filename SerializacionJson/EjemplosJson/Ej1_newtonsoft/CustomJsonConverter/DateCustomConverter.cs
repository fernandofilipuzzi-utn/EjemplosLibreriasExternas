using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej1_newtonsoft.CustomJsonConverter
{
    /// <summary>
    /// Ejemplo de uso:
    /// 
    /// [JsonProperty("fechaCustom")]
    /// [JsonConverter(typeof(DateCustomConverter))]
    /// [JsonConverter(typeof(DateTimeParametrizedCustomDateTimeConverter), "yyyy-MM-dd")]
    //// public DateTime FechaCustom { get { return Fecha; } set { Fecha = value; } }
    /// </summary>
    /// 
    public class DateCustomConverter : IsoDateTimeConverter
    {
        public DateCustomConverter()
        {
            DateTimeFormat = "yyyy-MM-dd";
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is DateTime dateTime)
            {
                string formattedValue = dateTime.ToString(DateTimeFormat);
                writer.WriteValue(formattedValue);
            }
            else
            {
                base.WriteJson(writer, value, serializer);
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value is string stringValue)
            {
                if (DateTime.TryParseExact(stringValue, DateTimeFormat, null, System.Globalization.DateTimeStyles.None, out DateTime result))
                {
                    return result;
                }
            }

            return base.ReadJson(reader, objectType, existingValue, serializer);
        }
    }
}
