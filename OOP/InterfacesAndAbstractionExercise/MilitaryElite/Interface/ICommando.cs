namespace MilitaryElite.Interface
{
    using System.Collections.Generic;
    using Model;

    public interface ICommando
    {
        public IReadOnlyCollection<Mission> Missions { get; }
    }
}