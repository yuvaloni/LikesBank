using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            A a = new A(1245);
            A a1 = new B(13, a);
            B b = new B(123, 321);
            a = new B(10, b);
            Console.WriteLine(((B)a).GetY());
            Console.ReadKey();
        }
    }
}
