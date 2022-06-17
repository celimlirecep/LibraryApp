using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.DAL.Abstract
{
    public interface IUnitOfWork:IDisposable
    {
        IBookRepository Books { get; }
        IUserCardRepository UserCards { get; }
        Task<int> SaveAsync();



    }
}
