using System;
using System.Collections.Generic;
using System.Text;

namespace Alchemist_Trial
{
    public class Enemy
    {
        // PROPERTIES OF EIGENSCHAPPEN
        // Hier slaan we de gegevens van de vijand op zoals de naam, health en damage.
        public string Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }

        // CONSTRUCTOR
        // Deze methode zorgt voor de opstartwaarden wanneer er een nieuwe vijand wordt gemaakt.
        public Enemy(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }

        // METHODES ALS FUNCTIES EN ACTIES

        // Zorgt ervoor dat de vijand levenspunten verliest als de speler aanvalt.
        public void TakeDamage(int amount)
        {
            Health -= amount;

            // Voorkomt dat de Health waarde onder de 0 zakt in de console.
            if (Health < 0)
            {
                Health = 0;
            }
        }

        // Controleert of de vijand nog leeft op basis van de huidige health.
        public bool IsAlive()
        {
            return Health > 0;
        }

        // Toont de statistieken van de vijand netjes onder elkaar.
        public void ShowStats()
        {
            Console.WriteLine("Enemy");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Health: {Health}");
            Console.WriteLine($"Damage: {Damage}");
        }

        // Voert een aanval uit op de speler.
        // Deze methode linkt de Enemy klasse direct aan de Player klasse.
        public void Attack(Player target)
        {
            Console.WriteLine($"{Name} valt jou aan!");

            // De schade van deze specifieke vijand wordt doorgegeven aan de TakeDamage methode van de speler.
            target.TakeDamage(this.Damage);

            Console.WriteLine($"Je verliest {this.Damage} HP! Je hebt nog {target.Health} HP over.");
        }
    }
}