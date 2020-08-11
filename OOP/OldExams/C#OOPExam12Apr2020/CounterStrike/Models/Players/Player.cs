namespace CounterStrike.Models.Players
{
    using System;
    using System.Text;
    using Contracts;
    using Guns.Contracts;
    using Utilities.Messages;

    public abstract class Player : IPlayer
    {
        private string _username;
        private int _healt;
        private int _armor;
        private bool _isAlive;
        private IGun _gun;

        public Player(string username, int health, int armor, IGun gun)
        {
            Username = username;
            Health = health;
            Armor = armor;
            Gun = gun;
        }

        public string Username
        {
            get => _username;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerName);

                _username = value;
            }
        }

        public int Health
        {
            get => _healt;
            private set
            {
                if (value < 0)
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerHealth);

                _healt = value;
            }
        }

        public int Armor
        {
            get => _armor;
            private set
            {
                if (value < 0)
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerArmor);

                _armor = value;
            }
        }

        public IGun Gun
        {
            get => _gun;
            private set
            {
                if (value == null)
                    throw new ArgumentException(ExceptionMessages.InvalidGun);

                _gun = value;
            }
        }

        public bool IsAlive => Health > 0;

        public virtual void TakeDamage(int points)
        {
            if (Armor > points)
            {
                Armor -= points;
                return;
            }

            if (IsAlive)
            {
                points -= Armor;
                var health = Health;
                health -= points < 0 ? points * -1 : points;
                Armor = 0;

                if (health < 0)
                {
                    Health = 0;
                }
                else
                    Health = health;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}: {Username}");
            sb.AppendLine($"--Health: {Health}");
            sb.AppendLine($"--Armor: {Armor}");
            sb.AppendLine($"--Gun: {Gun.Name}");

            return sb.ToString().TrimEnd();
        }
    }
}