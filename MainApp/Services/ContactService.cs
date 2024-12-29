using MainApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.Services
{
    public class ContactService
    {
        private List<Contact> _contacts = [];
        private readonly FileService _fileService = new();

        public void Add(Contact contact)
        {
            _contacts.Add(contact);
            _fileService.SaveListToFile(_contacts);
        }

        public IEnumerable<Contact> GetAll()
        {
            _contacts = _fileService.LoadListFromFile();
            return _contacts;
        }
    }
}
