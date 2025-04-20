using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Common
{
    public static class BookExtensions
    {
        // Метод розширення, який повертає короткий опис книги
        public static string GetShortDescription(this Book book)
        {
                return $"{book.Title} by {book.Author}";
        }
    }
}
