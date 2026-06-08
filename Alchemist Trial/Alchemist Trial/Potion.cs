using System;

namespace Alchemist_Trial
{
    public class Potion
    {
        // Alleen Name is universeel voor elke potion
        public string Name { get; set; }

        public Potion(string name)
        {
            Name = name;
        }

        public virtual void Use(Player player, Enemy enemy)
        {

        }
    }
}