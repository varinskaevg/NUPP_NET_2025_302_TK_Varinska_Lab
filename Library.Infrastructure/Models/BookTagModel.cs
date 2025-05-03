using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Models
{
    public class BookTagModel
    {
        public int BookId { get; set; }
        public BookModel Book { get; set; }

        public int TagId { get; set; }
        public TagModel Tag { get; set; }
    }
}
