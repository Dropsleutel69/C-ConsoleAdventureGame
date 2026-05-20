using System;
using System.Collections.Generic;
using System.Text;

namespace Alchemist_Trial
{
    public class Potion
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Power { get; set; }

        public Potion(string name, string type, int power)
        {
            Name = name;
            Type = type;
            Power = power;
        }

        public void Use(Player player, Enemy enemy)
        {
            if (Type == "Healing")
            {
                player.Health += Power;
                Console.WriteLine($"Je drinkt {Name} en krijgt {Power} HP terug!");
            }
            else if (Type == "Damage")
            {
                enemy.TakeDamage(Power);
                Console.WriteLine($"Je gooit {Name} naar {enemy.Name} voor {Power} Schade!");
            }
        }
    }
}
    