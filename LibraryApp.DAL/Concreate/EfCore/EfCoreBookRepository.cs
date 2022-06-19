using LibraryApp.DAL.Abstract;
using LİbraryApp.EL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.DAL.Concreate.EfCore
{
    public class EfCoreBookRepository : EfCoreGenericRepository<Book>, IBookRepository
    {
        public EfCoreBookRepository(LibraryContext context) : base(context)
        {

        }
        private LibraryContext libraryContext
        {
            get { return _context as LibraryContext; }
        }

        public async Task IncreaseBookCurrentStock(int bookId)
        {
            var book = await libraryContext.Books.FindAsync(bookId);
            book.CurrentStock += 1;
        }

        public async Task ReduceBookCurrentStock(int bookId)
        {
            var book = await libraryContext.Books.FindAsync(bookId);
            book.CurrentStock -= 1;
        }
    }
}
