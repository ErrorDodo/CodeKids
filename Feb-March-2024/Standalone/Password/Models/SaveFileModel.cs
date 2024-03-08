namespace Password.Models;

public class SaveFileModel
{
    public string Username { get; set; }
    public string Password { get; set; }
    public DateTime TimeSaved { get; set; } = DateTime.UtcNow;
}