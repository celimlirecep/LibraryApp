using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.API.DTO
{
    public class BookModel
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookImage { get; set; }
        public int CurrentStock { get; set; }
    }
}
