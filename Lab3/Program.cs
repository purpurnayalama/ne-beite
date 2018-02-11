using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            Pryamougolnik pryam = new Pryamougolnik(5, 6);
            Kvadrat kvad = new Kvadrat(4);
            krug kru = new krug(7);
            ArrayList al = new ArrayList();
            al.Add(kru);
            al.Add(pryam);
            al.Add(kvad);
            Console.WriteLine("Коллекция:");
            foreach (var x in al) Console.WriteLine(x);
            Console.WriteLine();
            Console.WriteLine("Сортировка:");
            al.Sort();
            foreach (var x in al) Console.WriteLine(x);
            Console.WriteLine();
            Console.WriteLine("Коллекция класса List<Figure>:");
            List<GeoFig> fl = new List<GeoFig>();
            fl.Add(kru);
            fl.Add(pryam);
            fl.Add(kvad);
            foreach (var x in fl) Console.WriteLine(x);
            Console.WriteLine();
            Console.WriteLine("Сортировка:"); fl.Sort();
            foreach (var x in fl) Console.WriteLine(x);
            Console.WriteLine();
            Console.WriteLine("Матрица:");
            Matrix<GeoFig> cube = new Matrix<GeoFig>(3, 3, 3, null);
            cube[0, 0, 0] = pryam;
            cube[1, 1, 1] = kvad;
            cube[2, 2, 2] = kru;
            Console.WriteLine(cube.ToString());
            Console.WriteLine("Стек:");
            SimpleStack<GeoFig> Stack1 = new SimpleStack<GeoFig>();
            Stack1.Push(pryam);
            Stack1.Push(kru);
            Stack1.Push(kvad);
            while (Stack1.Count > 0)
            {
                GeoFig fig = Stack1.Pop();
                Console.WriteLine(fig);
            }
            Console.ReadKey();
        }
    }
}
