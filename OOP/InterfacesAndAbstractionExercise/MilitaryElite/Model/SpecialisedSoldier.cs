namespace MilitaryElite.Model
{
    using System;
    using Interface;

    public abstract class SpecialisedSoldier : Soldier, ISpecialisedSoldier
    {

        public abstract string Corp { get; }

        protected SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corp) 
            : base(id, firstName, lastName, salary)
        {
        }

        protected override string DisplayInfo()
        {
            return $"{base.DisplayInfo()}{Environment.NewLine}" +
                   $"Corps: {Corp}";
        }
    }
}