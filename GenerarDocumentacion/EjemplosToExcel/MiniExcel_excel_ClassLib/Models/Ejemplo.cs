using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej1_NPOI.Models
{
    class Ejemplo
    {
        public int Numero { get; set; }
        public string Texto { get; set; }
        public DateTime Fecha { get; set; }
        public double Moneda { get; set; }


        static public List<Ejemplo> ListaDeEjemplos()
        {
            List<Ejemplo> personas = new List<Ejemplo>
            {
                new Ejemplo{ Numero=40122312, Texto="Ejemplo 1", Fecha=new DateTime(1995,02,1,3,4,5)},
                new Ejemplo{ Numero=40122312, Texto="Ejemplo 2", Fecha=new DateTime(1020,02,1,3,4,5)},
                new Ejemplo{ Numero=40122312, Texto="Ejemplo 3", Fecha=new DateTime(2000,02,1,3,4,5)},
                new Ejemplo{ Numero=40122312, Texto="Ejemplo 4", Fecha=new DateTime(2000,02,1,3,4,5)},
                new Ejemplo{ Numero=40122312, Texto="Ejemplo 5", Fecha=new DateTime(2000,02,1,3,4,5)},
            };
            return personas;
        }
    }
}
