using NhlSystemClassLibrary;
using System;

namespace NhlConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //create a new array with the names of 12 of your favorite game titles
            string[] game = new string[12] {"Kirby", "Mario Kart", "Mario Odyseey", "Homescapes", "Line Bubble", "Bloon Defense", "Stardew Valley", "Don't Starve", "Wordscapes", "My Hotpot Story", "Mario Party", "Mario"};

            // print the name of each game title using a foreach loop
            foreach (string gameName in game)
            {
                Console.WriteLine(gameName);
            }
            Console.WriteLine();
            //print the name of each game title using a for loop
            for(int i=0; i<game.Length; i++)
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
        }
    }
}