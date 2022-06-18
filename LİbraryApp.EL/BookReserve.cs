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
        private DateTime bookDeadline;
        public DateTime BookDeadline
        {
            get { return bookDeadline; }
            set { bookDeadline = BarrowingDate.AddDays(7); }
        }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int UserCardId { get; set; }
        public UserCard UserCard { get; set; }


    }
}
