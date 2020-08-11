namespace CounterStrike.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Contracts;
    using Models.Guns;
    using Models.Guns.Contracts;
    using Utilities.Messages;

    public class GunRepository : IRepository<IGun>
    {
        private List<IGun> _guns;

        public GunRepository() { _guns = new List<IGun>();}

        public IReadOnlyCollection<IGun> Models => _guns;

        public void Add(IGun gun)
        {
            if (gun == null)
                throw new ArgumentException(ExceptionMessages.InvalidGunRepository);

            _guns.Add(gun);
        }

        public bool Remove(IGun gun)
        {
            return _guns.Remove(gun);
        }

        public IGun FindByName(string name)
        {
            return _guns.FirstOrDefault(g => g.Name == name);
        }
    }
}