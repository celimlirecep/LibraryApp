using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.UI.Models
{
    public class LibraryBookModel
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookImage { get; set; }
        public DateTime BarrowingDate { get; set; }
        public DateTime BookDeadline { get; set; }
    }
}
