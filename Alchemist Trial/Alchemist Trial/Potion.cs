using System;
using System.Collections.Generic;
using System.Text;

namespace Alchemist_Trial
{
    public class Potion
    {
        // PROPERTIES OF EIGENSCHAPPEN
        // Slaat de specifieke gegevens van een potion op zoals de naam, het type en de kracht.
        public string Name { get; set; }
        public string Type { get; set; }
        public int Power { get; set; }

        // CONSTRUCTOR
        // Hiermee vullen we de eigenschappen zodra er een nieuwe potion wordt aangemaakt.
        public Potion(string name, string type, int power)
        {
            Name = name;
            Type = type;
            Power = power;
        }

        // METHODES ALS FUNCTIES EN ACTIES

        // Deze methode regelt wat er gebeurt als een speler een potion gebruikt.
        // Omdat een potion zowel de speler kan helen als een vijand kan raken, geven we beide objecten mee.
        public void Use(Player player, Enemy enemy)
        {
            // Logica voor een helende drank
            if (Type == "Healing")
            {
                player.Health += Power;
                Console.WriteLine($"Je drinkt {Name} en krijgt {Power} HP terug!");
            }
            // Logica voor een aanvallende drank zoals de Vuurfles
            else if (Type == "Damage")
            {
                enemy.TakeDamage(Power);
                Console.WriteLine($"Je gooit {Name} naar {enemy.Name} voor {Power} Schade!");
            }
        }
    }
}