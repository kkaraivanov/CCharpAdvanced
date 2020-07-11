namespace MilitaryElite.Interface
{
    using System.Collections.Generic;
    using Model;

    public interface ICommando
    {
        public IList<Mission> Missions { get; }
    }
}