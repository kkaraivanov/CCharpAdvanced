namespace Person
{
    using System;

    public class Child : Person
    {
        public Child(string name, int age) 
            : base(name, age)
        {
            this.Age = age;
        }

        public override int Age
        {
            protected set
            {
                if (value > 15)
                    throw new ArgumentException($"Child's can not be able to have an age more than 15.");

                base.Age = value;
            }
        }
    }
}
