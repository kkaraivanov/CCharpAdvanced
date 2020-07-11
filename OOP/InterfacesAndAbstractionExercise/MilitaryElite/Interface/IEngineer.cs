namespace MilitaryElite.Interface
{
    using System.Collections.Generic;
    using Model;

    public interface IEngineer
    {
        public IList<Repair> Repairs { get; }
    }
}