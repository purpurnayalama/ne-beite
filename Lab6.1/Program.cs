using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class Program
    {
        delegate int PowOrDiv(int x1, int x2);
        static int Pow(int i, int j)
        {
            return i * j;
        }
        static int Div(int i, int j)
        {
            return i / j;
        }
        static void Res(string str, int i, int j, PowOrDiv PowOrDivParam)
        {
            int N = PowOrDivParam(i, j);
            Console.WriteLine(str + N.ToString());
        }
        

        static void Main(string[] args)
        {
            Console.WriteLine("i = 6");
            Console.WriteLine("j = 3");
            int i = 6, j = 3;
            string str1 = "Умножение: ";
            Res(str1, i, j, (x, y) => { return x * y; });
            string str2 = "Деление: ";
            Res(str2, i, j, (x, y) => { return x / y; });
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Использование обощенного делегата Action<>:");
            Action<int, int> a1 = (x, y) => {
                Console.WriteLine("{0} * {1} = {2}", x, y, x * y);
            };
            Action<int, int> a2 = (x, y) => {
                Console.WriteLine("{0} / {1} = {2}", x, y, x / y);
            };
            Action<int, int> group = a1 + a2;
            group(i, j);
            Console.ReadKey();
        }
    }
}
