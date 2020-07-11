namespace MilitaryElite.Interface
{
    using System.Collections.Generic;
    using Model;

    public interface ILieutenantGeneral : IPrivate
    {
        public IReadOnlyCollection<Private> Solgers { get; }

    }
}