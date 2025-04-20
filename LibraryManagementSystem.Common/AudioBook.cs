using System;

namespace LibraryManagementSystem.Common
{
    public class AudioBook : Book
    {
        // Властивості
        public double DurationInHours { get; set; }

        public string Narrator { get; set; }

        public string AudioFormat { get; set; }

        // Статичне поле
        public static int TotalAudioBooksCount { get; set; } = 0;

        // Статичний метод
        public static int GetTotalAudioBooksCount()
        {
            return TotalAudioBooksCount;
        }

        // Статичний конструктор
        static AudioBook()
        {
            Console.WriteLine("AudioBook class has been initialized.");
        }

        // Конструктор
        public AudioBook(string title, string author, double durationInHours, string narrator, string audioFormat)
            : base(title, author, 0)
        {
            DurationInHours = durationInHours;
            Narrator = narrator;
            AudioFormat = audioFormat;
            TotalAudioBooksCount++;
        }

        // Метод
        public new void DisplayInfo()
        {
            Console.WriteLine($"AudioBook: {Title}, Author: {Author}, Duration: {DurationInHours}h, Narrator: {Narrator}, Format: {AudioFormat}");
        }
    }
}
