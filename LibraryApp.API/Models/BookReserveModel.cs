using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.API.Models
{
    public class BookReserveModel
    {
       
        public int UserCardId { get; set; }
        public List<BookItemModel> BookItems { get; set; }



    }
    public class BookItemModel
    {
        public int BookId { get; set; }
        public DateTime BarrowingDate { get; set; }
        

    }
}
