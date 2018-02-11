using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            Pryamougolnik pryam = new Pryamougolnik(5, 6);
            Kvadrat kvad = new Kvadrat(4);
            krug kru = new krug(7);
            pryam.Print();
            kvad.Print();
            kru.Print();            
            Console.ReadKey();
        }
    }
}
