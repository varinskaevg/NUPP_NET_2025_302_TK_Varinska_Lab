using System;

namespace LibraryManagementSystem.Common
{
    public class EBook : Book
    {
        // Властивості
        public string FileFormat { get; set; }

        public double FileSizeMB { get; set; }

        public bool IsDRMProtected { get; set; }

        // Статичне поле для лічильника електронних книг
        public static int TotalEBooksCount { get; set; } = 0;

        // Статичний метод
        public static int GetTotalEBooksCount()
        {
            return TotalEBooksCount;
        }

        // Конструктор
        public EBook(string title, string author, string fileFormat, double fileSizeMB, bool isDRMProtected)
            : base(title, author, 0)
        {
            FileFormat = fileFormat;
            FileSizeMB = fileSizeMB;
            IsDRMProtected = isDRMProtected;
            TotalEBooksCount++;
        }

        // Метод
        public new void DisplayInfo()
        {
            Console.WriteLine($"EBook: {Title}, Author: {Author}, Format: {FileFormat}, Size: {FileSizeMB}MB, DRM: {(IsDRMProtected ? "Yes" : "No")}");
        }
    }
}
