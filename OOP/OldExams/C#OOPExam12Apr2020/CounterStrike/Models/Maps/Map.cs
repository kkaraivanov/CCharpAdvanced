namespace CounterStrike.Models.Maps
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Players;
    using Players.Contracts;

    public class Map : IMap
    {
        public string Start(ICollection<IPlayer> players)
        {
            var _terorist = players.Where(t => t.GetType().Name == nameof(Terrorist)).ToList();
            var _counterTerorist = players.Where(t => t.GetType().Name == nameof(CounterTerrorist)).ToList();

            while (_counterTerorist.Any(t => t.IsAlive) && _terorist.Any(t => t.IsAlive))
            {
                foreach (var terorist in _terorist.Where(t => t.IsAlive))
                {
                    foreach (var counter in _counterTerorist.Where(ct => ct.IsAlive))
                    {
                        counter.TakeDamage(terorist.Gun.Fire());
                    }
                }

                foreach (var counter in _counterTerorist.Where(t => t.IsAlive))
                {
                    foreach (var terorist in _terorist.Where(ct => ct.IsAlive))
                    {
                        terorist.TakeDamage(counter.Gun.Fire());
                    }
                }
            }

            if(!_counterTerorist.Any(t => t.IsAlive))
                return "Terrorist wins!";
            else
                return "Counter Terrorist wins!";
        }
    }
}