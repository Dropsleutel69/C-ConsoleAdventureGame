using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace les
{
    internal class Cat : Animals
    {
        private int _lengthOfTail;
        public Cat(string name, int lengthOfTail) : base(name)
        {
            _lengthOfTail = lengthOfTail;
        }

        public void Miauw()
        {
            Console.WriteLine("MMMMIIIIIIIIAAAAAAAAAUUUUUUUUUUWWWWWWWWWWWWWWWWWWW!!!!!!!!!!!!");
            Console.WriteLine("I have a " +  _lengthOfTail + " centimeters long tail");
        }
    }
}
