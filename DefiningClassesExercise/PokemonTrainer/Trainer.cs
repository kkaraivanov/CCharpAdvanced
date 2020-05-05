namespace PokemonTrainer
{
    using System.Collections.Generic;
    using System.Linq;

    public class Trainer
    { 
        public string Name { get; }

        public int NumberOfBadges { get; set; }

        public List<Pokemon> Pokemons { get; private set; }

        public bool PokemonContainsElement(string element) => Pokemons.Any(x => x.Element == element);

        public Trainer(string name)
        {
            this.Name = name;
            this.NumberOfBadges = 0;
            this.Pokemons = new List<Pokemon>();
        }

        public void AddPocemon(Pokemon pokemon)
        {
            this.Pokemons.Add(pokemon);
        }

        public void ReducePokemonHealth()
        {
            foreach (var pokemon in Pokemons)
            {
                pokemon.HealthDown();
            }
        }

        public override string ToString()
        {
            return $"{this.Name} {this.NumberOfBadges} {this.Pokemons.Count}";
        }
    }
}
