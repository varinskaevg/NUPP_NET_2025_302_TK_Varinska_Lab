using Library.NoSql;
using Library.NoSql.Models;
using Library.NoSql.Repositories;
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        var connectionString = "mongodb+srv://ledimoana:Test1234@cluster0.jgfyrtu.mongodb.net/?retryWrites=true&w=majority";
        var repository = new MongoRepository<Book>(connectionString, "LibraryDb", "Books");

        var newBook = new Book
        {
            Title = "MongoDB Test Book",
            Author = "Test Author"
        };

        await repository.AddAsync(newBook);
        Console.WriteLine("Книгу додано.");

        var books = await repository.GetAllAsync();
        Console.WriteLine("Список книг:");
        foreach (var book in books)
        {
            Console.WriteLine($"- {book.Title} від {book.Author}");
        }
    }
}
