using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LİbraryApp.EL
{
    public class BookReserve
    {
        public int BookReserveId { get; set; }
        public DateTime BarrowingDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime BookDeadline { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int UserCardId { get; set; }
        public UserCard UserCard { get; set; }


    }
}
