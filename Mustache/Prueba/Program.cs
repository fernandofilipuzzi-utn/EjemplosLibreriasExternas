using Stubble.Core.Builders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //https://github.com/StubbleOrg/Stubble/blob/master/docs/how-to.md
            //libreria - Stubble.Core
            var stubble = new StubbleBuilder().Build();

            //datos
            var obj = new
            {
                Bar = "Bar",
                Foo = new Func<dynamic, string, object>((dyn, str) => { return str.Replace("World", dyn.Bar); })
            };

            //plantilla
            string template = "{{#Foo}} Hello World {{/Foo}}";

            var @out=stubble.Render(template, obj);
            
            Console.WriteLine(@out);
            Console.ReadKey();
        }
    }
}
