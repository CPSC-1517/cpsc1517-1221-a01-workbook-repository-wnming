using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesDemo.Models;
using System.Text.Json;
using System.Xml.Linq;

namespace RazorPagesDemo.Pages
{
    public class NhlPlayersModel : PageModel
    {
        private const string CsvFilePath = @"..\RazorPagesDemo\wwwroot\data\oilerPlayers.csv";
        private const string jsonFilePath = @"..\RazorPagesDemo\wwwroot\data\jsonPlayer.json";
        public List<Player> players { get; private set; } = new List<Player>();

        public Team team { get; private set; } = new Team();

        public void OnGet()
        {
            //ReadFromCsvFile(CsvFilePath);
            ReadFromJsonFile(jsonFilePath);
        }

        public void ReadFromJsonFile(string filePath)
        {
            try
            {
                string jsonString = System.IO.File.ReadAllText(filePath);
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    IncludeFields = true,
                };
                team = JsonSerializer.Deserialize<Team>(jsonString, options);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error serializing to Json file with exception: {ex.Message}");
            }
        }

        public void ReadFromCsvFile(string filePath)
        {
            string[] lineArray = System.IO.File.ReadAllLines(CsvFilePath);
            foreach (string line in lineArray)
            {
                try
                {
                    Player currentPlayer = new Player();
                    if (Player.TryParse(line, out currentPlayer))
                    {
                        players.Add(currentPlayer);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading file with exception {ex.Message}");
                }
            }
        }
    }
}
