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

        public async Task<List<Book>> GetBooksByUserId(string userId)
        {
           UserCard userCard= await libraryContext
                  .UserCards
                  .Where(i=>i.UserId==userId)
                  .Include(i => i.BookReserves)
                  .ThenInclude(i => i.Book)
                  .FirstOrDefaultAsync();
            List<Book> books = new List<Book>();
            foreach (var bookreserve in userCard.BookReserves)
            {
                Book book = new Book()
                {
                    BookId = bookreserve.BookId,
                    BookImage=bookreserve.Book.BookImage,
                    BookName=bookreserve.Book.BookName,
                    CurrentStock=bookreserve.Book.CurrentStock
                };
                books.Add(book);
            }
            return books;
        }
    }
}
