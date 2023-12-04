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
    /// 
    /// [JsonProperty("valorDecimal")]
    /// [JsonConverter(typeof(DoubleCustomConverter))]
    /// public double ValorDecimal { get; set; }
    /// </summary>
    /// 
    public class DoubleCustomConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is double doubleValue)
            {
                string formattedValue = doubleValue.ToString("0.00", CultureInfo.InvariantCulture); // Punto como separador decimal
                writer.WriteRawValue(formattedValue); // Usamos WriteRawValue para evitar la adición automática de comillas
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
                string stringValue = (string)reader.Value;

                if (double.TryParse(stringValue, NumberStyles.Any, CultureInfo.InvariantCulture, out double result))
                {
                    return result;
                }
                else
                {
                    throw new JsonSerializationException($"No se pudo convertir la cadena '{stringValue}' a un valor double.");
                }
            }
            else if (reader.TokenType == JsonToken.Float || reader.TokenType == JsonToken.Integer)
            {
                return Convert.ToDouble(reader.Value);
            }
            else
            {
                throw new JsonSerializationException($"Unexpected token type: {reader.TokenType}");
            }
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(double);
        }
    }


}
