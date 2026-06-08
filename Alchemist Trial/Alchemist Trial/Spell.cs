using System;
using System.Collections.Generic;
using System.Text;

namespace Alchemist_Trial
{
    public class Spell
    {
        public string Name { get; set; }
        public int ManaCost { get; set; }

        public Spell(string name, int manaCost)
        {
            Name = name;
            ManaCost = manaCost;
        }

        public virtual void Cast(Player player, Enemy enemy)
        {

        }
    }
}
