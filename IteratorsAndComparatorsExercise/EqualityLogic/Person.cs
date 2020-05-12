namespace EqualityLogic
{
    using System;

    public class Person : IComparable<Person>
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public int CompareTo(Person other)
        {
            if (this.name.CompareTo(other.name) != 0)
            {
                return this.name.CompareTo(other.name);
            }

            return this.age.CompareTo(other.age);
        }

        public override int GetHashCode() => this.name.GetHashCode() ^ this.age.GetHashCode();

        public override bool Equals(object obj)
        {
            var person = obj as Person;

            if (person == null)
            {
                return false;
            }

            return this.age == person.age && this.name == person.name;
        }
    }
}
