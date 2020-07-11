namespace MilitaryElite.Interface
{
    using System.Collections.Generic;
    using Model;

    public interface ICommando : ISpecialisedSoldier
    {
        public IReadOnlyCollection<Mission> Missions { get; }
    }
}