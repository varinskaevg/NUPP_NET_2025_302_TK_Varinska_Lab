using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Models
{
    public class AudioBookModel : BookModel
    {
        public string AudioFormat { get; set; }
        public double DurationInMinutes { get; set; }
    }
}
