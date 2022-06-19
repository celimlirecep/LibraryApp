using LİbraryApp.EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.DAL.Abstract
{
    public interface IBookRepository : IRepository<Book>
    {
     Task   ReduceBookCurrentStock(int bookId);
     Task IncreaseBookCurrentStock(int bookId);
    }
}
