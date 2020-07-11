namespace MilitaryElite.Interface
{
    using System.Collections.Generic;
    using Model;

    public interface IEngineer : ISpecialisedSoldier
    {
        public IReadOnlyCollection<Repair> Repairs { get; }
    }
}