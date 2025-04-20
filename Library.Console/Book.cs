using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Console
{
    public class Book : IEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }

        public Book(string title, string author, int pages)
        {
            Id = Guid.NewGuid();
            Title = title;
            Author = author;
            Pages = pages;
        }

        public static Book CreateRandom()
        {
            var titles = new[] { "1984", "Brave New World", "CLR via C#", "The Pragmatic Programmer", "Clean Code" };
            var authors = new[] { "George Orwell", "Aldous Huxley", "Jeffrey Richter", "Andy Hunt", "Robert C. Martin" };
            var rand = new Random(Guid.NewGuid().GetHashCode());

            string title = titles[rand.Next(titles.Length)];
            string author = authors[rand.Next(authors.Length)];
            int pages = rand.Next(100, 1000); // Випадкова кількість сторінок

            return new Book(title, author, pages);
        }
    }
}
