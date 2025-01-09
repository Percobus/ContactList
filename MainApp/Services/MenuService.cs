using MainApp.Models;


namespace MainApp.Services
{
    public class MenuService
    {
        private readonly ContactService _contactService = new();

        public void CreateUserDialog()
        {
            Console.Clear();

            var contact = new Contact();

            Console.Write("Fyll i ditt förnamn: ");
            contact.FirstName = Console.ReadLine()!;
            Console.Write("Fyll i ditt efternamn: ");
            contact.LastName = Console.ReadLine()!;
            Console.Write("Fyll i din email: ");
            contact.Email = Console.ReadLine()!;
            Console.Write("Fyll i ditt telefonnummer: ");
            contact.Phone = Console.ReadLine()!;
            Console.Write("Fyll i din gatuadress: ");
            contact.Street = Console.ReadLine()!;
            Console.Write("Fyll i ditt postnummer: ");
            contact.PostalCode = Console.ReadLine()!;
            Console.Write("Fyll i din ort: ");
            contact.City = Console.ReadLine()!;

            _contactService.Add(contact);
            Console.WriteLine("Kontakten har blivit tillagd!");

        }

        public void ViewAllContactsDialog()
        {
            Console.Clear();

            foreach (var contact in _contactService.GetAll())
            {
                Console.WriteLine($"{"Id:",-15}{contact.Id}");
                Console.WriteLine($"{"Namn:",-15}{contact.FirstName} {contact.LastName}");
                Console.WriteLine($"{"Email:",-15}{contact.Email}");
                Console.WriteLine($"{"Telefonnummer:",-15}{contact.Phone}");
                Console.WriteLine($"{"Adress:",-15}{contact.Street}, {contact.PostalCode}, {contact.City}");
                Console.WriteLine(" ");
            }

            Console.ReadKey();
        }
    }
}