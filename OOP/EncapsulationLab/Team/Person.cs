namespace PersonsInfo
{
    using System;

    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public Person(string name, string lastName, int age, decimal salary)
        {
            this.FirstName = name;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        private bool ValidateName(string name) => name?.Length > 2;

        public string FirstName
        {
            get => this.firstName;
            private set
            {
                if (ValidateName(value))
                    this.firstName = value;
                else
                    throw new ArgumentException("First firstName cannot contain fewer than 3 symbols!");
            }
        }

        public string LastName
        {
            get => this.lastName;
            private set
            {
                if (ValidateName(value))
                    this.lastName = value;
                else
                    throw new ArgumentException("Last firstName cannot contain fewer than 3 symbols!");
            }
        }

        public int Age
        {
            get => this.age;
            set
            {
                if (value > 0)
                    this.age = value;
                else
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
            }
        }

        public decimal Salary
        {
            get => this.salary;
            set
            {
                if (value < 460)
                    throw new ArgumentException("Salary cannot be less than 460 leva!");

                this.salary = value;
            }
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
