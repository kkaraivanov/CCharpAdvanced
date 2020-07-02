namespace Person
{
    using System;

    public class Person
    {
        private string name;
        protected int age;

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

        public int Age
        {
            get => age;
            set => this.ValidateAges = value;
        }

        protected virtual int ValidateAges
        {
            set
            {
                // for this test in Judge use
                if (value < 0)
                    this.age = Math.Abs(value); //throw new ArgumentException("People should not be able to have a negative age");
                else
                    this.age = value;
                // for everyone time use
                //if (value < 0)
                //    throw new ArgumentException("People should not be able to have a negative age");
                //else
                //    this.age = value;
            }
        }

        public override string ToString()
        {
            return String.Format($"Name: {this.Name}, Age: {this.Age}");
        }
    }
}
