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
    class EfCoreUserCardRepository : EfCoreGenericRepository<UserCard>, IUserCardRepository
    {
        public EfCoreUserCardRepository(LibraryContext context) : base(context)
        {

        }
        private LibraryContext libraryContext
        {
            get { return _context as LibraryContext; }
        }

        public async Task DeleteToUserCard(string userId, int bookId)
        {
           
            
            UserCard userCard = await libraryContext.UserCards.FirstOrDefaultAsync(i => i.UserId == userId);
            BookReserve bookReserve= await libraryContext.BookReserves.FirstOrDefaultAsync(i => i.UserCardId == userCard.UserCardId && i.BookId == bookId);
            bookReserve.Status = true;
            bookReserve.DeliveryDate = DateTime.Now;
          
           
           
        
            
       
        }

        public async Task<UserCard> GetUserCardByUserId(string userId) 
        {
            return  await libraryContext
                .UserCards
                .Include(i => i.BookReserves)
                .ThenInclude(i => i.Book)
                .FirstOrDefaultAsync(i => i.UserId == userId);
        }
    }
}
