namespace MilitaryElite.Model
{
    using System;
    using Interface;

    public class Spy : ISoldier
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int CodeNumber { get; set; }

        public Spy(int id, string firstName, string lastName, int codeNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            CodeNumber = codeNumber;
        }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} Id: {Id}{Environment.NewLine}" +
                   $"Code Number: {CodeNumber}";
        }
    }
}