namespace CounterStrike.Models.Guns
{
    using System;
    using Contracts;
    using Utilities.Messages;

    public abstract class Gun : IGun
    {
        private string _name;
        private int _bullentsCount;

        public Gun(string name, int bulletsCount)
        {
            Name = name;
            BulletsCount = bulletsCount;
        }

        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException(ExceptionMessages.InvalidGunName);

                _name = value;
            }
        }

        public int BulletsCount
        {
            get => _bullentsCount;
            protected set
            {
                if (value < 0)
                    throw new ArgumentException(ExceptionMessages.InvalidGunBulletsCount);

                _bullentsCount = value;
            }
        }

        public abstract int Fire();
    }
}