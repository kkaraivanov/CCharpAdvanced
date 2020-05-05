namespace PokemonTrainer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var trainers = new List<Trainer>();
            string command = null;

            while ((command = Console.ReadLine()) != "Tournament")
            {
                var input = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var nameContains = trainers.Select(x => x.Name).Contains(input[0]);
                var trainer = trainers
                    .FirstOrDefault(x => x.Name == input[0]);

                if (!nameContains)
                    trainers.Add(NewTrainer(input));
                else
                    trainer.AddPocemon(NewPokemon(input));
            }

            while ((command = Console.ReadLine()) != "End")
            {
                Tournament(command, trainers);
                RemoveDeadPokemons(trainers);
            }

            trainers
                .OrderByDescending(x => x.NumberOfBadges)
                .ToList()
                .ForEach(Console.WriteLine);
        }

        private static Trainer NewTrainer(string[] input)
        {
            var trainetr = new Trainer(input[0]);
            trainetr.AddPocemon(NewPokemon(input));

            return trainetr;
        }

        static Pokemon NewPokemon(string[] input)
        {
            return new Pokemon(input[1], input[2], int.Parse(input[3]));
        }

        private static void Tournament(string element, List<Trainer> trainers)
        {
            for (int i = 0; i < trainers.Count; i++)
            {
                var trainer = trainers[i];

                if (!trainer.PokemonContainsElement(element))
                {
                    trainer.ReducePokemonHealth();
                }
                else
                {
                    trainer.NumberOfBadges++;
                }
            }
        }

        static void RemoveDeadPokemons(List<Trainer> trainers)
        {
            foreach (var trainer in trainers)
            {
                trainer.Pokemons.RemoveAll(x => x.Health <= 0);
            }
        }
    }
}
