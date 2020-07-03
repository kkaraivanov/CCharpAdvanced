namespace PersonsInfo
{
    public class Person
    {
        private readonly string name;
        private readonly string lastName;
        private int age;

        public Person(string name, string lastName, int age)
        {
            this.name = name;
            this.lastName = lastName;
            this.age = age;
        }

        public string FirstName => this.name;

        public string LastName => this.lastName;

        public int Age
        {
            get => this.age;
        }

        public override string ToString()
        {
            return $"{FirstName} {lastName} is {age} years old.";
        }
    }
}
