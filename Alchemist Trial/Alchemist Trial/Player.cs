using System;
using System.Collections.Generic;
using System.Text;

namespace Alchemist_Trial
{
    public class Player
    {
        // PROPERTIES OF EIGENSCHAPPEN 
        // Hier slaan we de gegevens van de speler op die tijdens de game kunnen veranderen.
        public string Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }

        // De inventory is een lijst die alleen Potion objecten kan bevatten.
        public List<Potion> Inventory { get; set; } = new List<Potion>();

        // CONSTRUCTOR 
        // Deze methode draait één keer zodra er een new Player wordt aangemaakt.
        // Hiermee zetten we de beginwaarden of start stats van de speler klaar.
        public Player(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;

            // De speler begint standaard altijd met deze twee potions in zijn tas.
            Inventory.Add(new Potion("Kleine Healing Potion", "Healing", 20));
            Inventory.Add(new Potion("Vuurfles", "Damage", 25));
        }

        // METHODES ALS FUNCTIES EN ACTIES 

        // Zorgt ervoor dat de speler levenspunten verliest wanneer hij wordt aangevallen.
        public void TakeDamage(int amount)
        {
            Health -= amount;

            // Check om te voorkomen dat de Health onder de 0 zakt voor een nettere UI.
            if (Health < 0)
            {
                Health = 0;
            }
        }

        // Zorgt ervoor dat de speler levenspunten erbij krijgt bijvoorbeeld door een potion.
        public void Heal(int amount)
        {
            Health += amount;
        }

        // Een handige check die true of false teruggeeft om snel te controleren of de speler nog leeft.
        public bool IsAlive()
        {
            return Health > 0;
        }

        // Toont de huidige status en statistieken van de speler in de console.
        public void ShowStats()
        {
            Console.WriteLine("Player Stats");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Health: {Health}");
            Console.WriteLine($"Damage: {Damage}");
        }

        // Voert een aanval uit op een vijand.
        // Deze methode koppelt de Player klasse direct aan de Enemy klasse.
        public void Attack(Enemy target)
        {
            Console.WriteLine($"{Name} valt de {target.Name} aan!");

            // We roepen de TakeDamage methode aan van de vijand die we aanvallen,
            // en geven de Damage van de speler mee als argument.
            target.TakeDamage(this.Damage);

            Console.WriteLine($"{target.Name} verliest {this.Damage} HP.");
        }
    }
}