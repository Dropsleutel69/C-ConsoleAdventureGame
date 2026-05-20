using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class Animals
    {
        private string _eyeColor;
        //public string EyeColor;
        protected string EyeColor;
        { get => _eyeColor;
          private set
            {
                _eyeColor = value;
            }
        }

    }
}
