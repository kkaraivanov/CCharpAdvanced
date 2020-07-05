namespace FootballTeamGenerator.PlayerModel
{
    using System;
    using Common;

    public class Stats
    {
        private const int STATE_MIN_VALUE = 0;
        private const int STATE_MAX_VALUE = 100;
        private const double STAT_DELIMITER = 5.0;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public int Endurance
        {
            get => endurance;
            private set
            {
                ValidateStat(value, nameof(this.Endurance));

                endurance = value;
            }
        }

        public int Sprint
        {
            get => sprint;
            private set
            {
                ValidateStat(value, nameof(this.Sprint));

                sprint = value;
            }
        }

        public int Dribble
        {
            get => dribble;
            private set
            {
                ValidateStat(value, nameof(this.Dribble));

                dribble = value;
            }
        }

        public int Passing
        {
            get => passing;
            private set
            {
                ValidateStat(value, nameof(this.Passing));

                passing = value;
            }
        }

        public int Shooting
        {
            get => shooting;
            private set
            {
                ValidateStat(value, nameof(this.Shooting));

                shooting = value;
            }
        }

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public double AverageStat => (Endurance + Sprint + Dribble + Passing + Shooting) / STAT_DELIMITER;

        private void ValidateStat(int value, string stateName)
        {
            if (value < STATE_MIN_VALUE || value > STATE_MAX_VALUE)
                throw new InvalidOperationException(string.Format(GlobalConstants.InvalidStatExceptionMessage,
                    stateName, STATE_MIN_VALUE, STATE_MAX_VALUE));
        }
    }
}