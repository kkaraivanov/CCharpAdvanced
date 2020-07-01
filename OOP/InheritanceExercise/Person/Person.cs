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
                if (value.Length < 3)
                    throw new ArgumentException("Name's length should not be less than 3 symbols!");

                name = value;
            }
        }

        public virtual int Age
        {
            get => age;
            protected set
            {
                if (value < 0)
                    throw new ArgumentException("People should not be able to have a negative age");

                age = value;
            }
        }

        public override string ToString()
        {
            return String.Format("Name: {0}, Age: {1}", this.Name, this.Age);
        }
    }
}
