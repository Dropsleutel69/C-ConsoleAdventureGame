using System;
using System.Collections.Generic;
using System.Text;

namespace Alchemist_Trial
{
    public class Player
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }

        public Player (string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }

        public void TakeDamage(int amount)
        {
            Health -= amount;

            if (Health < 0)
            {
                Health = 0;
            }
        }

        public void Heal(int amount)
        {
            Health += amount;
        }

        public bool IsAlive()
        {
            return Health > 0;
        }

        public void ShowStats()
        {
            Console.WriteLine("------ Player Stats ------");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Health: {Health}");
            Console.WriteLine($"Damage: {Damage}");
            Console.WriteLine("--------------------------");
        }


    }
}
