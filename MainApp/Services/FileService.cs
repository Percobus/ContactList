using MainApp.Models;
using System.Diagnostics;
using System.Text.Json;

namespace MainApp.Services
{
    public class FileService
    {
        private readonly string _directoryPath;
        private readonly string _filePath;

        public FileService(string directoryPath = "Data", string filePath = "contactlist.json")             // Konstruktor som sätter standarvärden
        {
            _directoryPath = directoryPath;
            _filePath = Path.Combine(_directoryPath, filePath);
        }

        public void SaveListToFile (List<Contact> list)                                                    // Metod för att spara lista till fil
        {

            try
            {
                if (!Directory.Exists(_directoryPath))                                                    //  Kontrollerar om denna directory finns, annars skapar
                    Directory.CreateDirectory(_directoryPath);

                var json = JsonSerializer.Serialize(list);

                File.WriteAllText(_filePath, json);                                                       // Skriver JSON till filen
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public List<Contact> LoadListFromFile()                                                         // Metod för att läsa in listan från fil
        {
            try
            {
                if (!File.Exists(_filePath))                                                            // Om listan inte finns returnera en tom lista
                    return new List<Contact>();

                var json = File.ReadAllText(_filePath);                                                 // Läser in listan som en sträng
                var list = JsonSerializer.Deserialize<List<Contact>>(json);
                return list ?? new List<Contact>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return new List<Contact>();
            }


        }

    }
}
