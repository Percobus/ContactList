using MainApp.Models;


namespace MainApp.Services
{
    public class ContactService
    {
        private List<Contact> _contacts = [];                                   // Lista för kontakter
        private readonly FileService _fileService;                              // Hanterar filoperationer

        public ContactService(FileService fileservice)
        {
            _fileService = fileservice;
        }

        public void Add(Contact contact)                                        // Lägger till en ny kontakt till listan och sparar
        {
            _contacts.Add(contact);
            _fileService.SaveListToFile(_contacts);
        }

        public IEnumerable<Contact> GetAll()                                    // Hämtar alla kontakter från filen och returnerar
        {
            _contacts = _fileService.LoadListFromFile();
            return _contacts;
        }

        public bool ValidateContact(Contact contact)                            // Validerar en kontakt
        {
            return !string.IsNullOrWhiteSpace(contact.FirstName) && 
                !string.IsNullOrWhiteSpace(contact.LastName) &&
                !string.IsNullOrWhiteSpace(contact.Email) &&
                !string.IsNullOrWhiteSpace(contact.Phone);
        }
    }
}
