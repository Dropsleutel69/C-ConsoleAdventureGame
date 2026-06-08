using System;
using System.Collections.Generic;
using System.Text;

namespace Alchemist_Trial
{
    internal class HealingPotion : Potion
    {
        public int HealAmount { get; set; }
        public HealingPotion(string name, int healAmount) : base(name)
        {
            HealAmount = healAmount;
        }
        public override void Use(Player player, Enemy enemy)
        {
            player.Heal(HealAmount);
            Console.WriteLine($"Je drinkt {Name} en krijgt {HealAmount} HP terug!");
        }
    }
}
