namespace MilitaryElite.Model
{
    using System;
    using System.Text;
    using Enumerator;
    using Interface;

    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {

        public abstract string Corp { get; }
        private Corps corps;

        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corp) 
            : base(id, firstName, lastName, salary)
        {
            Corps = corp;
        }

        public string Corps
        {
            get => corps.ToString();
            set
            {
                Corps corps;

                if (!Enum.TryParse<Corps>(value, out corps))
                {
                    throw new ArgumentException();
                }

                this.corps = corps;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString())
                .AppendLine($"Corps: {Corps}");

            return sb.ToString().TrimEnd();
        }
    }
}