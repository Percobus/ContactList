using System;
using MainApp.Services;

namespace MainApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var menuService = new MenuService();                                        // Skapar en MenuService

            while (true)                                                                // While-loop som håller igång programmet
            {
                Console.Clear();
                Console.WriteLine("Inlämningsuppgift C# - En kontaktlista!");
                Console.WriteLine("********* Välj ett alternativ *********");
                Console.WriteLine(" ");
                Console.WriteLine("1. Se kontaktlistan");
                Console.WriteLine("2. Lägg till en kontakt");
                Console.WriteLine("3. Avsluta applikationen");
                Console.WriteLine(" ");
                Console.Write("Ditt val: ");

                var choice = Console.ReadLine();                                        // Sparar in användarens val

                switch (choice)                                                         // Switch för att hantera val
                {
                    case "1":
                        menuService.ViewAllContactsDialog();                            // Alternativ för att visa kontaktlistan
                        break;
                    case "2":
                        menuService.CreateUserDialog();                                 // Skapa en ny kontakt
                        break;
                    case "3":
                        Console.WriteLine("Välkommen åter!");                           // Dialog vid avslut av programmet
                        return;
                    default:
                        Console.WriteLine("Försök igen.");                              // Om valet är ogiltligt
                        break;
                }

                Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
                Console.ReadKey();
            }
        }
    }
}