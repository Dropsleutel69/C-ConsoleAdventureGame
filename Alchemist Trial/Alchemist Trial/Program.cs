using Alchemist_Trial;

Console.WriteLine("The Academy calls upon a new alchemist");
Console.Write("What is your name, apprentice?");

string playerName = Console.ReadLine();

Player player = new Player(playerName, 100, 15);

player.ShowStats();

Enemy wolf = new Enemy("Shadow wolf", 40, 8);
Console.WriteLine("\nA wild enemy appears!");
wolf.ShowStats();


while (player.IsAlive() && wolf.IsAlive())
{
    Console.WriteLine("\n--- Jouw beurt ---");
    Console.WriteLine("1. Aanvallen");
    Console.WriteLine("2. Status bekijken");

    string keuze = Console.ReadLine();

    if (keuze == "1")
    {
        player.Attack(wolf);
    }
    else if (keuze == "2")
    {
        player.ShowStats();
        wolf.ShowStats();
        continue;
    }
    else
    {
        Console.WriteLine("Ongeldige invoer! Je twijfelt en verliest je beurt.");
    }

    if (wolf.IsAlive())
    {
        Console.WriteLine("\n--- Beurt van de vijand ---");
        wolf.Attack(player);
    }
    if (!player.IsAlive())
    {
        Console.WriteLine("Je bent verslagen... Game Over.");
    }
}