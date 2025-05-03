using System.Collections.Generic;

namespace Library.Infrastructure.Models
{
    public class LibraryMemberModel
    {
        public int Id { get; set; }

        // 👇 Додай це, якщо ще немає
        public string Name { get; set; }

        // Один-до-багатьох: Учасник має багато книг
        public List<BookModel> BorrowedBooks { get; set; }
    }
}
