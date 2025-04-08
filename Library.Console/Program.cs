using System;
using System.Collections.Generic;
using LibraryManagementSystem.Common;
using Book = Library.Console.Book;

namespace Library.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICrudService<Book> bookService = new CrudService<Book>();

            var book1 = new Book("1984", "George Orwell", 1949);
            var book2 = new Book("Brave New World", "Aldous Huxley", 1932);

            bookService.Create(book1);
            bookService.Create(book2);

            System.Console.WriteLine("=== Книги після додавання ===");
            foreach (var book in bookService.ReadAll())
                System.Console.WriteLine(book);

            var updatedBook = new Book("1984", "George Orwell (Updated)", 1949);
            bookService.Update(updatedBook);

            System.Console.WriteLine("\n=== Книги після оновлення ===");
            foreach (var book in bookService.ReadAll())
                System.Console.WriteLine(book);

            bookService.Remove(book2);

            System.Console.WriteLine("\n=== Книги після видалення ===");
            foreach (var book in bookService.ReadAll())
                System.Console.WriteLine(book);

            bookService.Save("books.json");

            bookService = new CrudService<Book>();
            bookService.Load("books.json");

            System.Console.WriteLine("\n=== Книги після завантаження з файлу ===");
            foreach (var book in bookService.ReadAll())
                System.Console.WriteLine(book);

            System.Console.ReadKey();
        }
    }
}
