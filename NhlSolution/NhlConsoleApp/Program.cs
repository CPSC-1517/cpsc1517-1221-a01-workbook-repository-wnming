using NhlSystemClassLibrary;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NhlConsoleApp
{
    internal class Program
    {
        static Team ReadTeamFromJsonFile(string jsonPath)
        {
            Team team = null;
            try
            {
                string jsonString = File.ReadAllText(jsonPath);
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    IncludeFields = true,
                };
                team = JsonSerializer.Deserialize<Team>(jsonString, options);
                //team.players = new JsonSerializer.Deserialize<List<Player>>(jsonString, options);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error serializing to Json file with exception: {ex.Message}");
            }
            return team;
        }
        static void WriteTeamInfoToJsonFile(Team team, string jsonPath)
        {
            try
            {
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    IncludeFields = true,
                };
                string jsonString = JsonSerializer.Serialize<Team>(team, options);
                File.WriteAllText(jsonPath, jsonString);
                Console.WriteLine("Write to Json file was successful.");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error serializing to Json file with exception: {ex.Message}");
            }
        }
        static void PrintTeamInfo(Team team)
        {
            //4: display the team info and all players in the team
            Console.WriteLine($"{team.City} {team.Name} plays in {team.Arena}");
            foreach(Player player in team.players)
            {
                Console.WriteLine(player.ToString());
            }
        }
        static Team readPlayerDataFromCsv()
        {
            //1: create a new csv file with 5 sample players

            //2: crate a new Team instance
            Team team = new Team("Oilers", "Edmonton", "Rogers Place", Conference.Western, Division.Pacific);
            //3: write the code to read from the csv file using the Player TryParst method and write output to the screen
            string path = @"..\..\..\player.csv";
            string[] lineArray = File.ReadAllLines(path);
            foreach(string line in lineArray)
            {
                try
                {
                    Player player = null;
                    if (Player.TryParse(line, out player))
                    {
                        team.AddPlayer(player);
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Error reading file with exception {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading file with exception {ex.Message}");
                }
            }
            return team;
        }

        static void DemoLinq()
        {
            //create a new array with the names of 12 of your favorite game titles
            string[] game = new string[12] { "Kirby", "Mario Kart", "Mario Odyseey", "Homescapes", "Line Bubble", "Bloon Defense", "Stardew Valley", "Don't Starve", "Wordscapes", "My Hotpot Story", "Mario Party", "Mario" };

            // print the name of each game title using a foreach loop
            foreach (string gameName in game)
            {
                Console.WriteLine(gameName);
            }
            Console.WriteLine();
            //print the name of each game title using a for loop
            for (int i = 0; i < game.Length; i++)
            {
                Console.WriteLine(game[i]);
            }
            Console.WriteLine();
            //print the name of each game title using the Linq Enumerable ForEach method
            game.ToList()
            .ForEach(game => Console.WriteLine(game));
            Console.WriteLine();
            //sort the game title in asc order the nprint the name of each game
            game.OrderBy(game => game).ToList()
            .ForEach(game => Console.WriteLine(game));
            Console.WriteLine();
            //use the linq enumerable method Where to inclide only games with the mario keyword
            game.Where(game => game.Contains("Mario")).OrderBy(game => game).ToList()
            .ForEach(game => Console.WriteLine(game));
            Console.WriteLine();
            //using linq method Any() to determine if any games contains the Mario Title
            if (game.Any(game => game.Contains("Mario")))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
            Console.WriteLine();
            //using the linq method First() to return the first game with the title Mario
            string firstMarioGame = game.Where(game => game.Contains("Mario")).FirstOrDefault();
            Console.WriteLine(firstMarioGame);

        }

        static void Main(string[] args)
        {
            //Console.Write("Enter the team name: ");
            //string teamName = Console.ReadLine();

            //try
            //{
            //    //Team currentTeam = new Team(teamName);
            //    Team oiler = new Team("Oilers s", "Edmonton", "Rogers place", Conference.Western, Division.Pacific);
            //    //Console.WriteLine($"Team name: {oiler.Name}");
            //    Console.WriteLine($"Name: {oiler.Name}, City: {oiler.City}, Arena: {oiler.Arena}");
            //}
            //catch (ArgumentNullException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //catch(ArgumentException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            string jsonPath = @"..\..\..\jsonPlayer.json";
            //Team team = readPlayerDataFromCsv();
            Team team = ReadTeamFromJsonFile(jsonPath);
            PrintTeamInfo(team);
            WriteTeamInfoToJsonFile(team, jsonPath);
        }
    }
}