namespace DefiningClasses
{
    using System.Collections.Generic;
    using System.Linq;

    public class Family
    {
        private List<Person> People { get; set; }

        public Family()
        {
            People = new List<Person>();
        }

        public Person GetOldestMember()
        {
            var age = People.Select(x => x.Age).Max();
            var name = People.Where(x => x.Age == age).Select(x => x.Name).ToList()[0]; 
            var person = new Person(name, age);

            return person;
        }

        public void AddMember(Person member)
        {
            People.Add(member);
        }
    }
}
