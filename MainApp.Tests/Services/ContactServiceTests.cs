using System;
using System.IO;
using System.Linq;
using MainApp.Models;
using MainApp.Services;
using Xunit;

namespace MainApp.Tests
{
    public class ContactServiceTests : IDisposable
    {
        private string _testDirectoryPath;
        private string _testFilePath;
        private FileService _fileService;
        private ContactService _contactService;

        public ContactServiceTests()
        {
            _testDirectoryPath = "TestData";
            _testFilePath = Path.Combine(_testDirectoryPath, "testcontacts.json");
            _fileService = new FileService(_testDirectoryPath, "testcontacts.json");
            _contactService = new ContactService(_fileService);

            // Rensar upp eventuell testdata
            if (Directory.Exists(_testDirectoryPath))
                Directory.Delete(_testDirectoryPath, true);
        }

        public void Dispose()
        {
            // Ta bort testdata efter varje test
            if (Directory.Exists(_testDirectoryPath))
                Directory.Delete(_testDirectoryPath, true);
        }


        /* Nedan kod är genererad av ChatGPT 4.0 */

        [Fact]
        public void AddContact_ShouldSaveContactToFile()
        {
            var contact = new Contact
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Phone = "123456789",
                Street = "123 Main St",
                PostalCode = "12345",
                City = "Anytown"
            };

            _contactService.Add(contact);

            var savedContacts = _fileService.LoadListFromFile();
            Assert.Single(savedContacts);
            Assert.Equal("John", savedContacts[0].FirstName);
        }

        [Fact]
        public void GetAllContacts_ShouldReturnContactsFromFile()
        {
            var contact1 = new Contact { FirstName = "John", LastName = "Doe" };
            var contact2 = new Contact { FirstName = "Jane", LastName = "Doe" };

            _fileService.SaveListToFile(new List<Contact> { contact1, contact2 });

            var contacts = _contactService.GetAll().ToList();
            Assert.Equal(2, contacts.Count);
            Assert.Equal("John", contacts[0].FirstName);
            Assert.Equal("Jane", contacts[1].FirstName);
        }

        // Här börjar testerna för ValidateContact
        [Fact]
        public void ValidateContact_ShouldReturnTrueForValidContact()
        {
            // Arrange
            var contact = new Contact
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Phone = "123456789"
            };

            // Act
            var isValid = _contactService.ValidateContact(contact);

            // Assert
            Assert.True(isValid);
        }

        [Fact]
        public void ValidateContact_ShouldReturnFalseForInvalidContact()
        {
            // Arrange
            var contact = new Contact
            {
                FirstName = "",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Phone = "123456789"
            };

            // Act
            var isValid = _contactService.ValidateContact(contact);

            // Assert
            Assert.False(isValid);
        }
    }
}