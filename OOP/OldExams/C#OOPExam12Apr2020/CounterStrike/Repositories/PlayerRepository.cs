namespace CounterStrike.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Players.Contracts;
    using Utilities.Messages;

    public class PlayerRepository : IRepository<IPlayer>
    {
        private List<IPlayer> _players;

        public PlayerRepository() { _players = new List<IPlayer>(); }

        public IReadOnlyCollection<IPlayer> Models => _players;

        public void Add(IPlayer player)
        {
            if (player == null)
                throw new ArgumentException(ExceptionMessages.InvalidPlayerRepository);

            _players.Add(player);
        }

        public bool Remove(IPlayer player)
        {
            return _players.Remove(player);
        }

        public IPlayer FindByName(string name)
        {
            return _players.FirstOrDefault(p => p.Username == name);
        }
    }
}