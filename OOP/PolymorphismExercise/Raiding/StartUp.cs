namespace Raiding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Enumerator;
    using Model;

    public class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var heroes = new List<BaseHero>();

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                string heroType = Console.ReadLine();

                try
                {
                    var hero = CreateHero(name, heroType);
                    heroes.Add(hero);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    i--;
                }
            }

            int bossPower = int.Parse(Console.ReadLine());
            heroes.ForEach(x => Console.WriteLine(x.CastAbility()));
            if(heroes.Sum(x => x.Power) >= bossPower)
                Console.WriteLine("Victory!");
            else
                Console.WriteLine("Defeat...");
        }

        private static BaseHero CreateHero(string name, string type)
        {
            if(GetHero(type) == HeroType.Druid)
                return new Druid(name);
            else if (GetHero(type) == HeroType.Paladin)
                return new Paladin(name);
            else if (GetHero(type) == HeroType.Rogue)
                return new Rogue(name);
            else
                return new Warrior(name);
        }

        private static HeroType GetHero(string heroType)
        {
            HeroType hero;
            if (!Enum.TryParse<HeroType>(heroType, out hero))
               throw new ArgumentException("Invalid hero!");

            return hero;
        }
    }
}
