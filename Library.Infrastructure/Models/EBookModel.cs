using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Models
{
    public class EBookModel : BookModel
    {
        public string FileFormat { get; set; }
        public double FileSizeMB { get; set; }
    }
}
