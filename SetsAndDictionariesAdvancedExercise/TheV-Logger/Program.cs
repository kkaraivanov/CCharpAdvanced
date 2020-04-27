using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace TheV_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            //<vloger,<followera,followersList>>
            //<vloger,<following,followingList>>
            var vlogers = new Dictionary<string, Dictionary<string, List<string>>>();
            var followSkill = new string[] { "following", "followers" };
            var commands = new string[] { " joined The", " followed " };

            while (true)
            {
                string input = Console.ReadLine();
                string vloger = null;
                string temp = null;

                if (input.Contains("Statistics"))
                {
                    break;
                }

                if (input.Contains(commands[0]))
                {
                    vloger = input.Split(commands[0])[0];
                    temp = input.Split(commands[0])[1];

                    if (!vlogers.ContainsKey(vloger))
                    {
                        vlogers[vloger] = new Dictionary<string, List<string>>();
                        vlogers[vloger][followSkill[0]] = new List<string>();
                        vlogers[vloger][followSkill[1]] = new List<string>();
                    }
                }
                else if (input.Contains(commands[1]))
                {
                    vloger = input.Split(commands[1])[0];
                    temp = input.Split(commands[1])[1];
                    var vlogerName = vlogers.Keys.ToList();

                    if(!vlogers.ContainsKey(vloger) || !vlogers.ContainsKey(temp))
                        continue;

                    if(vloger == temp || vlogers[vloger][followSkill[0]].Contains(temp))
                        continue;

                    vlogers[vloger][followSkill[0]].Add(temp);
                    vlogers[temp][followSkill[1]].Add(vloger);
                }
            }

            int counter = 1;
            Console.WriteLine($"The V-Logger has a total of {vlogers.Count} vloggers in its logs.");

            foreach (var (vloger, follower) in vlogers
                .OrderByDescending(x => x.Value[followSkill[1]].Count)
                .ThenBy(x => x.Value[followSkill[0]].Count))
            {

                Console.WriteLine($"{counter}. {vloger} : {follower[followSkill[1]].Count} followers, {follower[followSkill[0]].Count} following");
                if(counter == 1)
                    Console.WriteLine($"{string.Join(Environment.NewLine, follower[followSkill[1]].OrderBy(x => x).Select(x => $"*  {x}"))}");

                counter++;
            }
        }
    }
}
