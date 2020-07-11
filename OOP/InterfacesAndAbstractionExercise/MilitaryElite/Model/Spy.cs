namespace MilitaryElite.Model
{
    using System;
    using System.Text;
    using Interface;

    public class Spy : Soldier, ISpy
    {

        public int CodeNumber { get; private set; }

        public Spy(int id, string firstName, string lastName, int code)
            : base(id, firstName, lastName)
        {
            CodeNumber = code;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString())
                .Append($"Code Number: {CodeNumber}");

            return sb.ToString();
        }

    }
}