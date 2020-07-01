namespace Person
{
    using System;

    public class Person
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name
        {
            get => name;
            private set
            {
                if(value.Length < 3)
                    throw new ArgumentException("Name's length should not be less than 3 symbols!");

                name = value;
            }
        }

        public virtual int Age
        {
            get => age;
            protected set
            {
                if(value < 0)
                    throw new ArgumentException($"The age of {Name} can not be able to have a negative value.");
                    
                age = value;
            }
        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }
    }
}
