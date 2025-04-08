using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Console
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Book other)
            {
                return Title == other.Title && Author == other.Author;
            }
            return false;
        }
        public Book(string title, string author, int year)
        {
            Title = title;
            Author = author;
        }

        public override int GetHashCode()
        {
            return Title.GetHashCode() ^ Author.GetHashCode();
        }

        public override string ToString()
        {
            return $"Title: {Title}, Author: {Author}";
        }
    }
}
