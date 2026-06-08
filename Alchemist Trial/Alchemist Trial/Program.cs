using Alchemist_Trial;

// INTRODUCTIE & KARAKTER CREATIE 
Console.WriteLine("Er is een nieuwe student bij de Academy!");
Console.Write("Wat is je naam, leerling? ");
string playerName = Console.ReadLine();

// Initialiseer de speler en de eerste vijand (Naam, HP, Attack Power)
Player player = new Player(playerName, 100, 15);
Enemy wolf = new Enemy("Schaduw wolf", 40, 8);

bool inMenu = true;

// HOOFDMENU LOOP 
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
        // Toon de huidige statistieken van de speler
        Console.Clear();
        player.ShowStats();

        Console.WriteLine("\nDruk op een toets om terug te gaan naar het menu");
        Console.ReadKey();
    }
    else if (menuKeuze == "2")
    {
        // Sluit het menu af om het spel te starten
        inMenu = false;
    }
    else
    {
        // Foutafhandeling bij ongeldige menu-invoer
        Console.WriteLine("\nOngeldige keuze! Probeer het nog een keertje");
        Console.ReadKey();
    }
}

// EERSTE ONTMOETING 
Console.Clear();
Console.WriteLine("\nEr verschijnt een wilde vijand!");
wolf.ShowStats();
Console.WriteLine("\nDruk op een toets om het gevecht te starten...");
Console.ReadKey();
Console.Clear();

// GEVECHT LOGICA: SCHADUW WOLF
// Het gevecht duurt voort zolang zowel de speler als de wolf leven
while (player.IsAlive() && wolf.IsAlive())
{
    Console.WriteLine($"BEURT VAN {player.Name.ToUpper()}:");
    Console.WriteLine("1. Aanvallen");
    Console.WriteLine("2. Status bekijken");
    Console.WriteLine("3. Potion gebruiken");

    string keuze = Console.ReadLine();

    if (keuze == "1")
    {
        // Speler valt de wolf aan
        player.Attack(wolf);
    }
    else if (keuze == "2")
    {
        // Stats bekijken pauzeert de beurt en herstart de loop via 'continue'
        player.ShowStats();
        wolf.ShowStats();
        Console.WriteLine("\nDruk op een toets om terug te gaan...");
        Console.ReadKey();
        Console.Clear();
        continue;
    }
    else if (keuze == "3")
    {
        // Check of de speler items in zijn inventory heeft
        if (player.Inventory.Count > 0)
        {
            // Toon alle beschikbare potions in de inventory
            for (int i = 0; i < player.Inventory.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {player.Inventory[i].Name}");
            }
            Console.Write("Welk nummer kies je? ");
            string potionInput = Console.ReadLine();

            // Valideer of de invoer een bestaand item-nummer is
            if (int.TryParse(potionInput, out int index) && index > 0 && index <= player.Inventory.Count)
            {
                // Potion ophalen, gebruiken en daarna verwijderen uit de inventory
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

    // Beurt van de vijand (als deze het gevecht tot nu toe heeft overleefd)
    if (wolf.IsAlive())
    {
        Console.WriteLine("\nBEURT VAN DE VIJAND");
        wolf.Attack(player);
    }

    Console.WriteLine("\nDruk op een toets voor de volgende ronde...");
    Console.ReadKey();
    Console.Clear();
}

// AFHANDELING AFLOOP EERSTE GEVECHT 
if (!player.IsAlive())
{
    Console.WriteLine("Je bent verslagen... Game Over.");
}
else if (!wolf.IsAlive())
{
    Console.WriteLine("Je hebt gewonnen!");

    // Loot-systeem op basis van kansberekening (Random)
    Random random = new Random();
    int lootKans = random.Next(1, 101); // Genereert een getal tussen 1 en 100

    Console.WriteLine("\nJe doorzoekt de omgeving van de shadow wolf");
    Console.WriteLine("Druk op een toets om te kijken wat je gevonden hebt!");
    Console.ReadKey();

    // 60% kans om buit te vinden
    if (lootKans <= 60)
    {
        Potion gevondenPotion;

        // 50/50 kans op een Healing Potion of een Vuurfles
        if (random.Next(0, 2) == 0)
        {
            gevondenPotion = new HealingPotion("Healing Potion", 20);
        }
        else
        {
            gevondenPotion = new DamagePotion("Vuurfles", 15);
        }

        player.Inventory.Add(gevondenPotion);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Wat een geluk! Je vind een {gevondenPotion.Name} op de grond en stopt hem in je tas");
        Console.ResetColor();
    }
    else
    {
        Console.WriteLine("Je hebt niks gevonden tussen de resten");
    }
    Console.ReadKey();
}

// VERHAALLIJN: DE SPLITSING
Console.Clear();
Console.WriteLine("Wat ga je nu doen?");
Console.WriteLine("1. volg het mysterieuze pad dieper het bos in");
Console.WriteLine("2. ga terug naar de Academy en geef op");
Console.WriteLine("maak je keuze:");

string reisKeuze = Console.ReadLine();

if (reisKeuze == "2")
{
    // Keuze 2: Speler geeft op en beëindigt het spel direct via 'return'
    Console.Clear();
    Console.WriteLine("je besluit dat het avontuur te gevaarlijk is");
    System.Threading.Thread.Sleep(2000);
    Console.WriteLine("Je keert terug naar de Academy");
    System.Threading.Thread.Sleep(3000);
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("het avontuur eindigt hier, GAME OVER");
    Console.ResetColor();

    Console.ReadKey();
    return;
}
else if (reisKeuze == "1")
{
    // Keuze 1: Het verhaal gaat verder richting de Boze Tovenaar
    Console.Clear();
    Console.WriteLine("je stapt dapper het donkere pad op");
    System.Threading.Thread.Sleep(2000);
    Console.WriteLine("na een tijdje zie je een gedaante in een paarse mantel staan");
    System.Threading.Thread.Sleep(3000);

    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("Het is een boze tovenaar!");
    Console.ResetColor();
    Console.WriteLine("druk een toets om dichterbij te komen");
    Console.ReadKey();

    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("Tovenaar: 'Wie waagt mijn rust te verstoren?!'");
    System.Threading.Thread.Sleep(1500);
    Console.WriteLine("Tovenaar: 'Een ranzige alchemist student... wat zielig.'");
    Console.ResetColor();
    Console.WriteLine("\n1. 'Ik ben hier om de Acadamy te wreken!");
    Console.WriteLine("\n2. 'Rustig aan oude man, ik loop al verder.");
    Console.Write("\nwat zeg je?");
    Console.ReadLine(); // Vangt de invoer op, maar doet er functioneel niks mee (puur voor het rollenspel)

    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("Tovenaar: 'Praatjes vullen geen gaatjes!'");
    System.Threading.Thread.Sleep(1500);
    Console.WriteLine("Tovenaar: 'Je daagt mij uit, of je scheert je nu weg!'");
    Console.ResetColor();
    System.Threading.Thread.Sleep(1500);
    Console.WriteLine("Wat doe je?");
    Console.WriteLine("\n");
    Console.WriteLine("1. Ga het gevecht aan met de Boze Tovenaar!");
    Console.WriteLine("2. Loop snel door en vermijd het gevecht!");
    Console.WriteLine("maak je keuze: ");

    string actieKeuze = Console.ReadLine();

    if (actieKeuze == "1")
    {
        // OPTIE A: HET GEVECHT MET DE TOVENAAR
        Console.Clear();
        Console.WriteLine("Je trekt je wapens");
        System.Threading.Thread.Sleep(1500);
        Console.WriteLine("Het gevecht met de Boze Tovenaar begint NU");
        System.Threading.Thread.Sleep(2000);

        // Instantieer een sterkere baas-vijand
        Enemy tovenaar = new Enemy("Boze Tovenaar", 60, 12);
        tovenaar.ShowStats();
        Console.WriteLine("Druk op een toets om de eerste klap uit te delen");
        Console.ReadKey();
        Console.Clear();

        // Tweede gevechtsloop (identiek aan de eerste gevechtsstructuur)
        while (player.IsAlive() && tovenaar.IsAlive())
        {
            Console.WriteLine($"BEURT VAN {player.Name.ToUpper()}:");
            Console.WriteLine("1. Aanvallen");
            Console.WriteLine("2. Status bekijken");
            Console.WriteLine("3. Potion gebruiken");

            string gevechtKeuze = Console.ReadLine();

            if (gevechtKeuze == "1")
            {
                player.Attack(tovenaar);
            }
            else if (gevechtKeuze == "2")
            {
                player.ShowStats();
                tovenaar.ShowStats();
                Console.WriteLine("\nDruk op een toets om terug te gaan...");
                Console.ReadKey();
                Console.Clear();
                continue;
            }
            else if (gevechtKeuze == "3")
            {
                if (player.Inventory.Count > 0)
                {
                    for (int i = 0; i < player.Inventory.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {player.Inventory[i].Name}");
                    }
                    Console.Write("Welk nummer kies je? ");
                    string potIn = Console.ReadLine();

                    if (int.TryParse(potIn, out int idx) && idx > 0 && idx <= player.Inventory.Count)
                    {
                        Potion gekozen = player.Inventory[idx - 1];
                        gekozen.Use(player, tovenaar);
                        player.Inventory.Remove(gekozen);
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

            if (tovenaar.IsAlive())
            {
                Console.WriteLine("\nBEURT VAN DE TOVENAAR");
                tovenaar.Attack(player);
            }

            Console.WriteLine("\nDruk op een toets voor de volgende ronde...");
            Console.ReadKey();
            Console.Clear();
        }

        // Resultaat na het gevecht met de tovenaar
        if (!player.IsAlive())
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("De tovenaar verbrand je tot as... Game Over.");
            Console.ResetColor();
        }
        else if (!tovenaar.IsAlive())
        {
            // Beloning voor het winnen van de Bossfight (gegarandeerde vaste loot)
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("JE HEBT DE BOZE TOVENAAR VERSLAGEN!");
            Console.WriteLine("Als beloning plunder je zijn laboratorium en vind je:");
            Console.WriteLine("- 2x Vuurfles");
            Console.WriteLine("- 3x Healing Potion");
            Console.ResetColor();

            player.Inventory.Add(new DamagePotion("Vuurfles", 15));
            player.Inventory.Add(new DamagePotion("Vuurfles", 15));
            player.Inventory.Add(new HealingPotion("Healing Potion", 20));
            player.Inventory.Add(new HealingPotion("Healing Potion", 20));
            player.Inventory.Add(new HealingPotion("Healing Potion", 20));

            Console.WriteLine("\nDruk op een toets om je gigantische buit te inspecteren en je tas te tellen...");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("Je Inventory:");
            Console.WriteLine($"Je doet je tas open en telt {player.Inventory.Count} item(s): \n");
            for (int i = 0; i < player.Inventory.Count; i++)
            {
                Console.WriteLine($"- {player.Inventory[i].Name}");
            }
            player.ShowStats();

            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("\nMet een bomvolle tas vol magische potions loop je trots terug naar de Academy");
            Console.WriteLine("Druk op een toets om de Academy te betreden");
            Console.ReadKey();
        }
    }
    else if (actieKeuze == "2")
    {
        // OPTIE B: HET GEVECHT VERMIJDEN
        Console.Clear();
        Console.WriteLine("Je slikt een keer diep, geeft de tovenaar een vriendelijk knikje en loopt snel door.");

        System.Threading.Thread.Sleep(2500);

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\nAchter je hoor je de tovenaar nog hard lachen: 'Haha! Verstandige keuze, snotneus!'");
        Console.ResetColor();

        System.Threading.Thread.Sleep(3000);
        Console.Clear();

        Console.WriteLine("Na een flink stuk rennen plof je vermoeid neer onder een grote eikenboom.");
        System.Threading.Thread.Sleep(2000);
        Console.WriteLine("Je hebt de tovenaar overleefd, maar je hebt helaas geen extra potions kunnen bemachtigen.");
        System.Threading.Thread.Sleep(2000);

        Console.WriteLine("\nGelukkig heb je de Shadow wolf wel verslagen!");
        System.Threading.Thread.Sleep(1500);
        Console.WriteLine("Druk op een toets om je tas te openen en je spullen te tellen");
        Console.ReadKey();

        Console.Clear();
        Console.WriteLine("Inventory: ");
        if (player.Inventory.Count > 0)
        {
            Console.WriteLine($"Je doet je tas open and telt {player.Inventory.Count} item(s): \n");
            for (int i = 0; i < player.Inventory.Count; i++)
            {
                Console.WriteLine($"- {player.Inventory[i].Name}");
            }
        }
        else
        {
            Console.WriteLine("Je doet je tas open, Helemaal leeg! Volgende keer toch die tovenaar maar uitdagen?");
        }

        player.ShowStats();
        System.Threading.Thread.Sleep(2000);
        Console.WriteLine("\nJe raapt jezelf bij elkaar en loopt met trillende benen terug naar de Academy");
        Console.WriteLine("Druk op een toets om de Academy te betreden");
        Console.ReadKey();
    }

    // GAME ENDING: DE ACADEMY BEOORDELING
    Console.Clear();
    Console.WriteLine("Je stapt de grote poort van de Academy binnen");
    System.Threading.Thread.Sleep(2000);
    Console.WriteLine("Alchemist Meester Jamiro staat op je te wachten in de centrale hal");
    System.Threading.Thread.Sleep(2500);

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine($"\nMeester Jamiro: 'Ah {player.Name} Je bent teruggekeerd van je avontuur, laat me je tas zien");
    Console.ResetColor();
    System.Threading.Thread.Sleep(2000);

    Console.WriteLine("\nJe overhandigt je tas aan de meester");
    System.Threading.Thread.Sleep(1500);
    Console.WriteLine("Hij kijkt er aandachtig in");
    System.Threading.Thread.Sleep(3000);
    Console.Clear();

    // Dynamische beoordeling op basis van het aantal verzamelde items in de inventory
    Console.ForegroundColor = ConsoleColor.Cyan;
    if (player.Inventory.Count >= 4)
    {
        // Gewonnen van de tovenaar (veel loot)
        Console.WriteLine("Meester Jamiro: 'Bij merlijns baard!! Zoveel potions? Je hebt die boze tovenaar verslagen!");
        System.Threading.Thread.Sleep(2000);
        Console.WriteLine("Je bent geen normale leerling meer... je bent een ware Alchemist Master!");
    }
    else if (player.Inventory.Count > 0)
    {
        // Alleen gewonnen van de wolf (en loot-kans gehad) of weggesprint
        Console.WriteLine("Meester Jamiro: 'Ik zie dat je de schaduw wolf hebt verslagen. Goed gedaan!");
        System.Threading.Thread.Sleep(2000);
        Console.WriteLine("Meester Jamiro: 'Je hebt overleefd en brengt loot mee naar huis. Je bent geslaagd voor je avontuur!");
    }
    else
    {
        // Wolf verslagen maar geen loot gekregen én tovenaar ontweken (lege tas)
        Console.WriteLine("Meester Jamiro: 'Je tas is leeg... maar je bent levend uit het donkere bos gekomen!");
        System.Threading.Thread.Sleep(2000);
        Console.WriteLine("Meester Jamiro: 'Overleven is de eerste les van een Alchemist. Je krijgt een herkansing.");
    }

    Console.ResetColor();
    Console.WriteLine("druk op een toets om naar het eind scherm te gaan.");
    Console.ReadKey();

    // OUTRO / DEMO CREDITS
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("                 ALCHEMIST TRIAL - BEDANKT VOOR HET SPELEN!    ");
    Console.ResetColor();
    Console.WriteLine($"\nBedankt voor het spelen van deze demo, {player.Name}!");
    Console.WriteLine("Je hebt uniek pad bewandeld en je eigen keuzes gemaakt.");
    Console.WriteLine("\nIn de volledige game:");
    Console.WriteLine("- Ontdek meer gebieden in het magische bos");
    Console.WriteLine("- Leer zelf potions brouwen met verzamelde ingrediënten");
    Console.WriteLine("- Upgrade je stats en ontmoet legendarische NPC's");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("\n[ TO BE CONTINUED... ]");
    Console.ResetColor();

    Console.WriteLine("\nDruk op een toets om de game volledig af te sluiten.");
    Console.ReadKey();
}