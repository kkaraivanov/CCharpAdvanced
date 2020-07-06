namespace FootballTeamGenerator.FootballTeams
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using PlayerModel;
    using TeamModel;

    public class Teams
    {
        private List<Team> teams;

        public Teams()
        {
            teams = new List<Team>();
        }

        private string[] ReadLine => Console.ReadLine()
            ?.Split(';', StringSplitOptions.None)
            .ToArray();

        public void Make()
        {
            var commands = ReadLine;
            while (!commands.Contains("END"))
            {
                string teamName = null;
                string playerName = null;

                if(commands.Length > 1)
                    teamName = commands[1];

                if(commands.Length > 2)
                    playerName = commands[2];

                try
                {
                    if (commands[0] == "Team")
                    {
                        var team = new Team(commands[1]);
                        teams.Add(team);
                    }

                    if (commands[0] == "Add")
                    {
                        teamName.IsValidTeamName(teams);

                        var stats = NewStats(commands.Skip(3).ToArray());
                        var player = new Player(playerName, stats);
                        var team = teams.First(x => x.Name == teamName);
                        team.AddPlayer(player);
                    }

                    if (commands[0] == "Remove")
                    {
                        teamName.IsValidTeamName(teams);

                        var team = teams.First(x => x.Name == teamName);
                        team.RemovePlayer(playerName);
                    }

                    if (commands[0] == "Rating")
                    {
                        teamName.IsValidTeamName(teams);

                        var team = teams.First(x => x.Name == teamName);
                        Console.WriteLine(team);
                    }
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }

                commands = ReadLine;
            }
        }

        private Stats NewStats(string[] inputArr)
        {
            int endurance = int.Parse(inputArr[0]);
            int sprint = int.Parse(inputArr[1]);
            int dribble = int.Parse(inputArr[2]);
            int passing = int.Parse(inputArr[3]);
            int shooting = int.Parse(inputArr[4]);

            return new Stats(endurance, sprint, dribble, passing, shooting);
        }
    }
}