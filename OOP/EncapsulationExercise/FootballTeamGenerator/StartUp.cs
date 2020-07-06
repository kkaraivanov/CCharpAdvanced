namespace FootballTeamGenerator
{
    using System;
    using FootballTeams;

    public class StartUp
    {
        static void Main()
        {
            try
            {
                var teams = new Teams();
                teams.Make();
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
