using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LİbraryApp.EL
{
    public class UserCard
    {
        public int UserCardId { get; set; }
        public string UserId { get; set; }
        public List<BookReserve> BookReserves { get; set; }

    }
}
