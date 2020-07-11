namespace MilitaryElite.Interface
{
    using System.Collections.Generic;
    using Model;

    public interface ILieutenantGeneral
    {
        public IReadOnlyCollection<Private> Solgers { get; }

    }
}