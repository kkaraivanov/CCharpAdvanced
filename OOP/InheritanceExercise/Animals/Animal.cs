namespace Animals
{
    using System;
    using System.Text;

    public class Animal : IProduceSound
    {
        private string name;
        private int age;
        private string gender;

        private bool ValidateStringInput(string s) => string.IsNullOrWhiteSpace(s);

        private bool ValidateGenderInput(string s) => (s == "Female" ? true : false) || (s == "Male" ? true : false);

        public string Name
        {
            get => name;
            private set
            {
                if(ValidateStringInput(value))
                    throw new ArgumentException("Invalid input!");

                name = value;
            }
        }

        public int Age
        {
            get => age;
            private set
            {
                if (ValidateStringInput(value.ToString()) && value < 0)
                    throw new ArgumentException("Invalid input!");

                age = value;
            }
        }

        public string Gender
        {
            get => gender;
            private set
            {
                if (ValidateStringInput(value) || !ValidateGenderInput(value))
                    throw new ArgumentException("Invalid input!");

                gender = value;
            }
        }

        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public virtual string ProduceSound()
        {
            return null;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}");
            sb.AppendLine($"{ Name} { Age} { Gender}");
            sb.AppendLine($"{this.ProduceSound()}");

            return sb.ToString().TrimEnd();
        }
    }
}