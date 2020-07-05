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
            catch (InvalidOperationException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
        }
    }
}
