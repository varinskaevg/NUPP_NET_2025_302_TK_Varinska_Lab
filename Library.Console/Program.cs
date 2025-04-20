using Library.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        var service = new CrudServiceAsync<Book>("books.json");

        // Створення книг з обмеженням потоків за допомогою Semaphore
        Console.WriteLine("Creating books with semaphore...");
        var tasks = new List<Task>();
        for (int i = 0; i < 10; i++)
        {
            tasks.Add(SynchronizationExamples.RunSemaphoreExampleAsync());
        }
        await Task.WhenAll(tasks);

        // Додавання книг у сховище
        Console.WriteLine("Creating books in service...");
        for (int i = 0; i < 5; i++)
        {
            var book = Book.CreateRandom();
            await service.CreateAsync(book);
        }

        // Демонстрація lock
        Console.WriteLine("Running lock example...");
        SynchronizationExamples.RunLockExample();

        // AutoResetEvent
        Console.WriteLine("Running AutoResetEvent example...");
        SynchronizationExamples.RunAutoResetEventExample();
        await Task.Delay(1500); // Чекаємо, поки потік відпрацює

        // ManualResetEvent
        Console.WriteLine("Running ManualResetEvent example...");
        SynchronizationExamples.RunManualResetEventExample();
        await Task.Delay(1500); // Чекаємо, поки потік відпрацює

        // Статистика книг
        var allBooks = (await service.ReadAllAsync()).ToList();
        if (allBooks.Count > 0)
        {
            int min = allBooks.Min(b => b.Pages);
            int max = allBooks.Max(b => b.Pages);
            double avg = allBooks.Average(b => b.Pages);

            Console.WriteLine($"Books count: {allBooks.Count}");
            Console.WriteLine($"Min pages: {min}");
            Console.WriteLine($"Max pages: {max}");
            Console.WriteLine($"Avg pages: {avg:F2}");
        }
        else
        {
            Console.WriteLine("No books found.");
        }

        // Збереження у файл
        await service.SaveAsync();
        Console.WriteLine("Data saved to file.");
    }
}
