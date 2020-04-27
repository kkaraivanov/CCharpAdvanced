using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            // format <contest, password>
            var contests = new Dictionary<string, string>();

            while (true)
            {
                // format {contest}:{password for contest}
                string input = Console.ReadLine();

                if(input == "end of contests")
                    break;

                var inputSplit = input.Split(':').ToArray();
                string contest = inputSplit[0];
                string contestPassword = inputSplit[1];

                if (!contests.ContainsKey(contest))
                    contests[contest] = string.Empty;

                contests[contest] = contestPassword;
            }

            // format <username, <contest, point>>
            var users = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                // format {contest}=>{password}=>{username}=>{points}
                string input = Console.ReadLine();

                if(input == "end of submissions")
                    break;

                var inputSplit = input.Split("=>").ToArray();
                string contest = inputSplit[0];
                string contestPassword = inputSplit[1];
                string username = inputSplit[2];
                int points = int.Parse(inputSplit[3]);

                if (contests.ContainsKey(contest))
                {
                    if (contests[contest] == contestPassword)
                    {
                        if(!users.ContainsKey(username))
                            users[username] = new Dictionary<string, int>();

                        if (!users[username].ContainsKey(contest))
                            users[username][contest] = 0;

                        if (users[username][contest] < points)
                            users[username][contest] = points;
                    }
                }
            }

            string bestCandidate = null;
            int bestPoints = 0;
            foreach (var (user, points) in users)
            {
                int userPoints = 0;
                foreach (var (contest, point) in points)
                {
                    userPoints += point;
                }

                if (bestPoints < userPoints)
                {
                    bestPoints = userPoints;
                    bestCandidate = user;
                }
            }
            
            Console.WriteLine($"Best candidate is {bestCandidate} with total {bestPoints} points.");
            Console.WriteLine("Ranking:");
            foreach (var (user, points) in users
                .OrderBy(x => x.Key))
            {
                Console.WriteLine($"{user}");
                Console.WriteLine(string.Join(
                    Environment.NewLine,
                    points
                        .OrderByDescending(x => x.Value)
                        .Select(x => $"#  {x.Key} -> {x.Value}")));
            }
        }
    }
}
