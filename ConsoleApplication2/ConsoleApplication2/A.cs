using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class A
    {
        protected int x;
        public A(int x)
        {
            SetX(x);
            Console.WriteLine("IN A WITH {0}", this.x);

        }
        public void SetX(int x)
        {
            if (x > 100 && x < 10000)
                this.x = x / 100 + x % 100 * 100;
            else
                this.x = x;
        }
        public virtual int GetX()
        {
            return x;
        }
    }
}
