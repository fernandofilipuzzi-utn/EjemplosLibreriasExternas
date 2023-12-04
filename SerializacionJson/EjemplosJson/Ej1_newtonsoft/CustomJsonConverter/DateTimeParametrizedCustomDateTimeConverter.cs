using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej1_newtonsoft.CustomJsonConverter
{
    /// <summary>
    /// Ejemplo de uso:
    /// [JsonProperty("fechaHoraCustom")]
    /// [JsonConverter(typeof(DateTimeParametrizedCustomDateTimeConverter), "yyyy-MM-ddTHH:mm:ss")]
    /// public DateTime Fecha { get; set; }
    /// </summary>
    /// 
    public class DateTimeParametrizedCustomDateTimeConverter : JsonConverter
    {
        private readonly string dateTimeFormat;

        public DateTimeParametrizedCustomDateTimeConverter(string format)
        {
            dateTimeFormat = format;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is DateTime dateTime)
            {
                string formattedValue = dateTime.ToString(dateTimeFormat, CultureInfo.InvariantCulture);
                writer.WriteValue(formattedValue);
            }
            else
            {
                writer.WriteNull();
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
            {
                string stringValue = reader.Value.ToString();

                if (DateTime.TryParseExact(stringValue, dateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
                {
                    return result;
                }
            }
            else if (reader.TokenType == JsonToken.Date)
            {
                return reader.Value;
            }

            return null;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime);
        }
    }
}
