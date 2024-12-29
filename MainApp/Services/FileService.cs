using MainApp.Models;
using System.Diagnostics;
using System.Text.Json;

namespace MainApp.Services
{
    public class FileService
    {
        private readonly string _directoryPath;
        private readonly string _filePath;

        public FileService(string directoryPath = "Data", string filePath = "contactlist.json")
        {
            _directoryPath = directoryPath;
            _filePath = Path.Combine(_directoryPath, filePath);
        }

        public void SaveListToFile (List<Contact> list)
        {

            try
            {
                if (!Directory.Exists(_directoryPath))
                    Directory.CreateDirectory(_directoryPath);

                var json = JsonSerializer.Serialize(list);

                File.WriteAllText(_filePath, json);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public List<Contact> LoadListFromFile()
        {
            try
            {
                if (!File.Exists(_filePath))
                    return [];

                var json = File.ReadAllText(_filePath);
                var list = JsonSerializer.Deserialize<List<Contact>>(json);
                return list ?? [];
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return[];
            }


        }

    }
}
