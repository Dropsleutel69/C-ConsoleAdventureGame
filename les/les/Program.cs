using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace les
{
    internal class Program
    {
        static void Main(string[] args)
        {
            work work = new work();
            work.Start();
        }
    }
}
