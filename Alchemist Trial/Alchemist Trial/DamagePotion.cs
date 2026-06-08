using System;
using System.Collections.Generic;
using System.Text;

namespace Alchemist_Trial
{
    internal class DamagePotion : Potion
    {
        public int DamageAmount { get; set; }

        public DamagePotion(string name, int damageAmount) : base(name)
        {
            DamageAmount = damageAmount;
        }

        public override void Use(Player player, Enemy enemy)
        {
            enemy.TakeDamage(DamageAmount);
            Console.WriteLine($"Je gooit {Name} naar {enemy.Name} voor {DamageAmount} schade!");
        }
    }
}
