namespace BirthdayCelebrations
{
    using System;
    using Interface;

    public class Pet : INamed, IBirthable
    {
        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        public Pet(string name, string birthdate)
        {
            Name = name;
            Birthdate = DateTime.ParseExact(birthdate, "dd/mm/yyyy", null);
        }
    }
}