using System;

namespace LibraryManagementSystem.Common
{
    public class Book
    {
        // Властивості
        public string Title { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }

        // Статичне поле для лічильника книг
        public static int TotalBooksCount { get; set; } = 0;

        // Статичний метод для отримання загальної кількості книг
        public static int GetTotalBooksCount()
        {
            return TotalBooksCount;
        }

        // Статичний конструктор
        static Book()
        {
            Console.WriteLine("Book class has been initialized.");
        }

        // Конструктор
        public Book(string title, string author, int pages)
        {
            Title = title;
            Author = author;
            Pages = pages;
            TotalBooksCount++; // Кожен новий об'єкт збільшує загальну кількість книг
        }

        // Метод
        public void DisplayInfo()
        {
            Console.WriteLine($"Book: {Title}, Author: {Author}, Pages: {Pages}");
        }
    }
}
