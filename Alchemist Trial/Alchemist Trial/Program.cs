using Alchemist_Trial;

Console.WriteLine("The Academy calls upon a new alchemist");
Console.Write("What is your name, apprentice? ");
string playerName = Console.ReadLine();

Player player = new Player(playerName, 100, 15);
Enemy wolf = new Enemy("Shadow wolf", 40, 8);

bool inMenu = true;

while (inMenu)
{
    Console.Clear();
    Console.WriteLine("Alchemist Trial - MENU");
    Console.WriteLine("Wat wil je gaan doen?");
    Console.WriteLine("1. Bekijk je stats");
    Console.WriteLine("2. Start je avontuur!");

    string menuKeuze = Console.ReadLine();

    if (menuKeuze == "1")
    {
        Console.Clear();
        player.ShowStats();

        Console.WriteLine("\nDruk op een toets om terug te gaan naar het menu");
        Console.ReadKey();
    }
    else if (menuKeuze == "2")
    {
        inMenu = false;
    }
    else
    {
        Console.WriteLine("\nOngeldige keuze! Probeer het nog een keertje");
        Console.ReadKey();
    }
}

Console.Clear();
Console.WriteLine("\nA wild enemy appears!");
wolf.ShowStats();
Console.WriteLine("\nDruk op een toets om het gevecht te starten...");
Console.ReadKey();
Console.Clear();

while (player.IsAlive() && wolf.IsAlive())
{
    Console.WriteLine($"BEURT VAN {player.Name.ToUpper()}:");
    Console.WriteLine("1. Aanvallen");
    Console.WriteLine("2. Status bekijken");
    Console.WriteLine("3. Potion gebruiken");

    string keuze = Console.ReadLine();

    if (keuze == "1")
    {
        player.Attack(wolf);
    }
    else if (keuze == "2")
    {
        player.ShowStats();
        wolf.ShowStats();
        Console.WriteLine("\nDruk op een toets om terug te gaan...");
        Console.ReadKey();
        Console.Clear();
        continue;
    }
    else if (keuze == "3")
    {
        if (player.Inventory.Count > 0)
        {
            for (int i = 0; i < player.Inventory.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {player.Inventory[i].Name}");
            }
            Console.Write("Welk nummer kies je? ");
            string potionInput = Console.ReadLine();

            if (int.TryParse(potionInput, out int index) && index > 0 && index <= player.Inventory.Count)
            {
                Potion gekozenPotion = player.Inventory[index - 1];
                gekozenPotion.Use(player, wolf);
                player.Inventory.Remove(gekozenPotion);
            }
            else
            {
                Console.WriteLine("Ongeldig nummer! Je raakt in de war en gebruikt niks.");
            }
        }
        else
        {
            Console.WriteLine("Je hebt geen potions meer!");
        }
    }
    else
    {
        Console.WriteLine("Ongeldige invoer! Je twijfelt en verliest je beurt.");
    }

    if (wolf.IsAlive())
    {
        Console.WriteLine("\nBEURT VAN DE VIJAND");
        wolf.Attack(player);
    }

    Console.WriteLine("\nDruk op een toets voor de volgende ronde...");
    Console.ReadKey();
    Console.Clear();
}

if (!player.IsAlive())
{
    Console.WriteLine("Je bent verslagen... Game Over.");
}
else if (!wolf.IsAlive())
{
    Console.WriteLine("Je hebt gewonnen!");
}

Console.WriteLine("\nDruk op een toets om af te sluiten.");
Console.ReadKey();