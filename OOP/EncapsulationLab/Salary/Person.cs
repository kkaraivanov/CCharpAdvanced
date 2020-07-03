namespace PersonsInfo
{
    public class Person
    {
        private readonly string name;
        private readonly string lastName;
        private readonly int age;
        private decimal salary;

        public Person(string name, string lastName, int age, decimal salary)
        {
            this.name = name;
            this.lastName = lastName;
            this.age = age;
            Salary = salary;
        }

        public string FirstName => this.name;

        public string LastName => this.lastName;

        public int Age => this.age;

        public decimal Salary
        {
            get => this.salary;
            private set => this.salary = value;
        }

        public void IncreaseSalary(decimal percentage)
        {
            if (this.Age > 30)
            {
                this.Salary += this.Salary * percentage / 100;
            }
            else
            {
                this.Salary += this.Salary * percentage / 200;
            }
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} receives {Salary:f2} leva.";
        }
    }
}
