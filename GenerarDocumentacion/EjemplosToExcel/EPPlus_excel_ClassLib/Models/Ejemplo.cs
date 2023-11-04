using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPPlus_excel_ClassLib.Models
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
                new Ejemplo{ Numero=40122312, Texto="Ejemplo 1", Fecha=new DateTime(1995,3,1,0,0,0)},
                new Ejemplo{ Numero=40122312, Texto="Ejemplo 2", Fecha=new DateTime(1995,2,1,3,4,5)},
                new Ejemplo{ Numero=40122312, Texto="Ejemplo 3", Fecha=new DateTime(1920,4,3,6,7,8)},
                new Ejemplo{ Numero=40122312, Texto="Ejemplo 4", Fecha=new DateTime(2020,5,6,9,10,11)},
                new Ejemplo{ Numero=40122312, Texto="Ejemplo 5", Fecha=new DateTime(2022,7,8,12,13,14)},
                new Ejemplo{ Numero=40122312, Texto="Ejemplo 6", Fecha=new DateTime(2003,9,10,15,16,17)}
            };
            return personas;
        }
    }
}
