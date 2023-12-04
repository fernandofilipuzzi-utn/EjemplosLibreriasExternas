using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ej1_newtonsoft.CustomJsonConverter
{
    /// <summary>
    /// Ejemplo de uso:
    /// 
    /// [JsonConverter(typeof(DateTimeCustomConverter))]
    //// public DateTime FechaHoraCustom { get { return FechaHora; } set { FechaHora = value; } }
    /// </summary>

    public class DateTimeCustomConverter : IsoDateTimeConverter
    {
        public DateTimeCustomConverter()
        {
            DateTimeFormat = "yyyy-MM-ddTHH:mm:ss";
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
