using Ej1_newtonsoft.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej1_newtonsoft
{
    class Program
    {
        static void Main(string[] args)
        {
            #region probando la serializacion
            Registro ej = new Registro
            {
                ValorEntero = 23,
                ValorDecimal = 32.2,
                ValorDecimal14F2 = 1 / 3.0,
                Fecha = new DateTime(2023, 12, 05, 13, 3, 1),
                FechaHora = new DateTime(2023, 12, 04, 13, 2, 1)
            };

            string jsonString = JsonConvert.SerializeObject(ej);
            ImprimirObjecto(jsonString);
            #endregion

            #region probando deserializar
            string jsonEntrante = "{\"valorEntero\": 23,"+
                                      "\"valorDecimal\": \"32,20\"," +
                                      "\"valorDecimal14F2\": \"0,33\"," +
                                      "\"fechaCustom\": \"2023-12-05\"," +
                                      "\"fechaHoraCustom\":\"2023-12-04T13:02:01\""+
                                  "}";

            try
            {
                Registro ejEntrante = JsonConvert.DeserializeObject<Registro>(jsonEntrante);
                Console.WriteLine(ejEntrante);
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"{ex.Message}\n{ex.StackTrace}");
            }

            #endregion

            Console.ReadKey();
        }

        public static void ImprimirObjecto(string jsonString)
        {
            JObject jsonObject = JObject.Parse(jsonString);
            string formattedJson = jsonObject.ToString(Formatting.Indented);
            Console.WriteLine(formattedJson);
        }
    }
}
