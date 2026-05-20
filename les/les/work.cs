using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace les
{
    internal class work
    {
        Cat Nala = new Cat("Nala", 67);
        public void Start()
        {
            Nala.Sleep();
            Nala.Miauw();
            Nala.SayName();
        }

    }
}
