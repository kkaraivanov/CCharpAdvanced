namespace Person
{
    using System;

    public class Child : Person
    {
        public Child(string name, int age) 
            : base(name, age)
        {
            this.ValidateAges = age;
        }

        protected override int ValidateAges
        {
            set
            {
                // for this test in Judge use
                base.age = value;
                // for everyone time use
                //if (value > 15)
                //    throw new ArgumentException("Children should not be able to have an age more than 15");
                //else
                //    base.age = value;
            }
        }
    }
}
