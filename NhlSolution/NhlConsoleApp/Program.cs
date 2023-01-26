using NhlSystemClassLibrary;
namespace NhlConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.Write("Enter the team name: ");
            //string teamName = Console.ReadLine();

            try
            {
                //Team currentTeam = new Team(teamName);
                Team oiler = new Team("Oilers s", "Edmonton", "Rogers place", Conference.Western, Division.Pacific);
                //Console.WriteLine($"Team name: {oiler.Name}");
                Console.WriteLine($"Name: {oiler.Name}, City: {oiler.City}, Arena: {oiler.Arena}");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}