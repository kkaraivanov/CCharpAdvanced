﻿namespace FootballTeamGenerator.PlayerModel
{
    using System;
    using Common;

    public class Stats
    {
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

        public double AverageStat => (Endurance + Sprint + Dribble + Passing + Shooting) / GlobalConstants.STAT_DELIMITER;

        private void ValidateStat(int value, string stateName)
        {
            if (value < GlobalConstants.STATE_MIN_VALUE || value > GlobalConstants.STATE_MAX_VALUE)
                throw new InvalidOperationException(string.Format(GlobalConstants.InvalidStatExceptionMessage,
                    stateName, GlobalConstants.STATE_MIN_VALUE, GlobalConstants.STATE_MAX_VALUE));
        }
    }
}