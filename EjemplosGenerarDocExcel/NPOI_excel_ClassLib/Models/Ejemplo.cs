using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOI_excel_ClassLib.Models
{
    class Ejemplo
    {
        public int NumeroCorto { get; set; }
        public int Numero { get; set; }
        public long Cuit { get; set; }
        public string Texto { get; set; }
        public DateTime Fecha { get; set; }
        public double Moneda { get; set; }
        
        static Random azar=new Random();
        public static int ShortGen
        {
            get {  return azar.Next(0, 10); } 
        }
        public static int ShortLong
        {
            get { return azar.Next(1456550, 45456550); }
        }

        static public List<Ejemplo> ListaDeEjemplos()
        {
            List<Ejemplo> personas = new List<Ejemplo>
            {
                 new Ejemplo{ NumeroCorto=ShortGen, Numero=ShortLong, Cuit=20401223122, Texto="Ejemplo 1", Fecha=new DateTime(1995,3,1,0,0,0), Moneda=00.0},
                new Ejemplo{ NumeroCorto=ShortGen, Numero=ShortLong, Cuit=2071223122, Texto="Ejemplo 2", Fecha=new DateTime(1995,2,1,3,4,5), Moneda=0.2},
                new Ejemplo{ NumeroCorto=ShortGen, Numero=ShortLong, Cuit=20061223122, Texto="Ejemplo 3", Fecha=new DateTime(1920,4,3,6,7,8), Moneda=1.0},
                new Ejemplo{ NumeroCorto=ShortGen, Numero=ShortLong, Cuit=20401223122, Texto="Ejemplo 4", Fecha=new DateTime(2020,5,6,9,10,11), Moneda=1.2},
                new Ejemplo{ NumeroCorto=ShortGen, Numero=ShortLong, Cuit=20401223122, Texto="Ejemplo 5", Fecha=new DateTime(2022,7,8,12,13,14), Moneda=23423.2},
                new Ejemplo{ NumeroCorto=ShortGen, Numero=ShortLong, Cuit=20401223122, Texto="Ejemplo 6", Fecha=new DateTime(2003,9,10,15,16,17), Moneda=23423.2}
            };
            return personas;
        }
    }
}
