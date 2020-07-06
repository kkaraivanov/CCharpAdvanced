namespace FootballTeamGenerator.PlayerModel
{
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
                value.IsValidState(nameof(this.Endurance));

                endurance = value;
            }
        }

        public int Sprint
        {
            get => sprint;
            private set
            {
                value.IsValidState(nameof(this.Sprint));

                sprint = value;
            }
        }

        public int Dribble
        {
            get => dribble;
            private set
            {
                value.IsValidState(nameof(this.Dribble));

                dribble = value;
            }
        }

        public int Passing
        {
            get => passing;
            private set
            {
                value.IsValidState(nameof(this.Passing));

                passing = value;
            }
        }

        public int Shooting
        {
            get => shooting;
            private set
            {
                value.IsValidState(nameof(this.Shooting));

                shooting = value;
            }
        }

        public double AverageStat => (Endurance + Sprint + Dribble + Passing + Shooting) / GlobalConstants.STAT_DELIMITER;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }
    }
}