namespace CounterStrike.Models.Players
{
    using Guns.Contracts;

    public class CounterTerrorist : Player
    {
        public CounterTerrorist(string username, int health, int armor, IGun gun) 
            : base(username, health, armor, gun)
        {
        }
    }
}