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
            private set => name = value;
        }

        public virtual int Age
        {
            get => age;
            protected set
            {
                if (value < 0)
                    this.age = Math.Abs(value); //throw new ArgumentException("People should not be able to have a negative age");

                this.age = value;
            }
        }

        public override string ToString()
        {
            return String.Format($"Name: {this.Name}, Age: {this.Age}");
        }
    }
}
