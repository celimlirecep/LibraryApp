using LİbraryApp.EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.BL.Abstract
{
    public interface IBookService
    {
        Task<List<Book>> GetAll();
    }
}
