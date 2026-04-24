using Alchemist_Trial;

Console.WriteLine("The Academy calls upon a new alchemist");
Console.Write("What is your name, apprentice?");

string playerName = Console.ReadLine();

Player player = new Player(playerName, 100, 15);

player.ShowStats();