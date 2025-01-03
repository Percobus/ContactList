using System;
using MainApp.Services;

namespace MainApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var menuService = new MenuService();

            while (true)
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

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": 
                        menuService.ViewAllContactsDialog();
                        break;
                    case "2":
                        menuService.CreateUserDialog();
                        break;
                    case "3":
                        Console.WriteLine("Välkommen åter!");
                        return;
                    default:
                        Console.WriteLine("Försök igen.");
                        break;
                }

                Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
                Console.ReadKey();
            }
        }
    }
}

