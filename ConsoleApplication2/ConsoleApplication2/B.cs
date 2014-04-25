using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class B:A
    {
        private A a;
        public B(int x, A y):base(x)
        {
            this.a = y;
            Console.WriteLine("IN B WITH {0}", GetX());

        }
        public B(int x, int y) : this(x, new A(y)) { }
        public int GetY() { return a.GetX(); }
        public override int GetX()
        {

            return x + a.GetX();
        }
    }
}
