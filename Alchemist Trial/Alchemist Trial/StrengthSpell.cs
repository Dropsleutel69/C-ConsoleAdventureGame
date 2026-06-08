using System;
using System.Collections.Generic;
using System.Text;

namespace Alchemist_Trial
{
    internal class StrengthSpell : Spell
    {
        public int ExtraDamage { get; set; }

        public StrengthSpell(string name, int manaCost, int extraDamage)
            : base(name, manaCost)
        {
            ExtraDamage = extraDamage;
        }

        public override void Cast(Player player, Enemy enemy)
        {
            player.Damage += ExtraDamage;
        }
    }
}