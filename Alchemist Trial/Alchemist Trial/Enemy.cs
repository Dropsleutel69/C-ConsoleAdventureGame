using System;
using System.Collections.Generic;
using System.Text;

namespace Alchemist_Trial
{
    public class Enemy
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }

        public Enemy(string name, int health, int damage)
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

        public bool IsAlive()
        {
            return Health > 0;
        }

        public void ShowStats()
        {
            Console.WriteLine("Enemy");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Health: {Health}");
            Console.WriteLine($"Damage: {Damage}");
        }

        public void Attack(Player target)
        {
            Console.WriteLine($"{Name} valt jou aan!");
            target.TakeDamage(this.Damage);
            Console.WriteLine($"Je verliest {this.Damage} HP! Je hebt nog {target.Health} HP over.");
        }
    }
}
