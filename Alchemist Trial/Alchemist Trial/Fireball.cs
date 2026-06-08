using System;
using System.Collections.Generic;
using System.Text;

namespace Alchemist_Trial
{
    internal class Fireball : Spell
    {
        public int Damage { get; set; }

        public Fireball(string name, int manaCost, int damage) : base(name, manaCost)
        {
            Damage = damage;
        }

        public override void Cast(Player player, Enemy enemy)
        {
            enemy.TakeDamage(Damage);
        }
    }
}
