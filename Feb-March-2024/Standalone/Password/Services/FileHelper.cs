using Newtonsoft.Json;
using Password.Models;

namespace Password.Services;

public class FileHelper
{
    public bool SaveFile(string username, string password)
    {
        var saveLocation = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        var fileModel = new SaveFileModel
        {
            Username = username,
            Password = password
        };

        try
        {
            var jsonData = JsonConvert.SerializeObject(fileModel, Formatting.Indented);
            File.AppendAllText(saveLocation + "/password.json", jsonData);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }
}