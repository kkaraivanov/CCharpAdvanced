namespace IteratorsAndComparators
{
    using System.Collections.Generic;

    public class Book
    {
        private List<string> authors;

        public Book(string title, int year, params string[] authors)
        {
            this.Title = title;
            this.Year = year;
            this.authors = new List<string>(authors);
        }

        public string Title { get; private set; }

        public int Year { get; private set; }

        public IReadOnlyList<string> Authors => this.authors.AsReadOnly();
    }
}
