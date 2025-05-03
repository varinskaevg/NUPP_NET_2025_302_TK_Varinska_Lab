using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Models
{
    public class TagModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Багато-до-багатьох: Один тег – багато книжок
        public List<BookTagModel> BookTags { get; set; }
    }
}
