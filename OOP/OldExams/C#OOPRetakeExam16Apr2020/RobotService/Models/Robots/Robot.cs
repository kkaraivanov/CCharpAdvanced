namespace RobotService.Models.Robots
{
    using System;
    using Contracts;
    using Utilities.Messages;

    public abstract class Robot : IRobot
    {
        private int _happiness;
        private int _energy;

        public string Name { get; private set; }

        public int Happiness
        {
            get => _happiness;
            set
            {
                if(value < 0 || 100 < value)
                    throw new ArgumentException(ExceptionMessages.InvalidHappiness);

                _happiness = value;
            }
        }

        public int Energy
        {
            get => _energy;
            set
            {
                if (value < 0 || 100 < value)
                    throw new ArgumentException(ExceptionMessages.InvalidEnergy);

                _energy = value;
            }
        }

        public int ProcedureTime { get; set; }

        public string Owner { get; set; } = "Service";

        public bool IsBought { get; set; } = false;

        public bool IsChipped { get; set; } = false;

        public bool IsChecked { get; set; } = false;

        protected Robot(string name, int energy, int happiness, int procedureTime)
        {
            Name = name;
            Energy = energy;
            Happiness = happiness;
            ProcedureTime = procedureTime;
        }

        public override string ToString()
        {
            return string.Format(OutputMessages.RobotInfo,this.GetType().Name, Name, Happiness, Energy);
        }
    }
}