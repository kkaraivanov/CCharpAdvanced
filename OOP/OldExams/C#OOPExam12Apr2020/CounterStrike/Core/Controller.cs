namespace CounterStrike.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using Contracts;
    using Models.Guns;
    using Models.Guns.Contracts;
    using Models.Maps;
    using Models.Maps.Contracts;
    using Models.Players;
    using Models.Players.Contracts;
    using Repositories;
    using Utilities.Messages;

    public class Controller : IController
    {
        private readonly GunRepository _guns;
        private readonly PlayerRepository _players;
        private readonly IMap _game;

        public Controller()
        {
            _guns = new GunRepository();
            _players = new PlayerRepository();
            _game = new Map();
        }

        public string AddGun(string type, string name, int bulletsCount)
        {
            if(!Enum.TryParse(type, out GunType gunType))
                throw new ArgumentException(ExceptionMessages.InvalidGunType);

            IGun gun = null;
            switch (gunType)
            {
                case GunType.Pistol:
                    gun = new Pistol(name, bulletsCount);
                    break;
                case GunType.Rifle:
                    gun = new Rifle(name, bulletsCount);
                    break;
            }
            _guns.Add(gun);

            return string.Format(OutputMessages.SuccessfullyAddedGun, name);
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            var gun = _guns.FindByName(gunName);
            if (gun == null)
                throw new ArgumentException(ExceptionMessages.GunCannotBeFound);

            if (!Enum.TryParse(type, out PlayerType playerType))
                throw new ArgumentException(ExceptionMessages.InvalidGunType);

            IPlayer player = null;
            switch (playerType)
            {
                case PlayerType.Terrorist:
                    player = new Terrorist(username, health, armor, gun);
                    break;
                case PlayerType.CounterTerrorist:
                    player = new CounterTerrorist(username, health, armor, gun);
                    break;
            }
            _players.Add(player);

            return string.Format(OutputMessages.SuccessfullyAddedPlayer, username);
        }

        public string StartGame()
        {
            ICollection<IPlayer> players = _players.Models as ICollection<IPlayer>;
            return $"{_game.Start(players)}";
        }

        public string Report()
        {
            return $"{string.Join(Environment.NewLine, _players.Models.OrderBy(p => p.GetType().Name).ThenByDescending(p => p.Health))}";
        }
    }
}