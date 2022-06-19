using LibraryApp.BL.Abstract;
using LibraryApp.DAL.Abstract;
using LİbraryApp.EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.BL.Concreate
{
    public class UserCardManager : IUserCardService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserCardManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<string> AddToCard(string userId, int bookId)
        {
            var userCard = await _unitOfWork.UserCards.GetUserCardByUserId(userId);
            if (userCard != null)
            {
                //added book will not be added again
                var index = userCard.BookReserves.FindIndex(i => i.BookId == bookId);
                //Maximum of 3 books available.
                int activeBookCount = 0;
                foreach (var item in userCard.BookReserves)
                {
                    if (item.Status==false)
                    {
                        activeBookCount++;
                    }
                }

                if (index<0 && activeBookCount < 3)
                {
                    userCard.BookReserves.Add(new BookReserve() { 
                    BookId=bookId,
                    BarrowingDate=DateTime.Now,
                    UserCardId=userCard.UserCardId,
                    BookDeadline=DateTime.Now.AddDays(7)

                    });
                    await _unitOfWork.Books.ReduceBookCurrentStock(bookId);
                    await _unitOfWork.SaveAsync();
                    return "Registration Successful";
                }
            }
            return "you have read before";
        }

        public async Task DeleteToCard(string userId, int bookId)
        {
             await _unitOfWork.UserCards.DeleteToUserCard(userId,bookId);
            await _unitOfWork.Books.IncreaseBookCurrentStock(bookId);
           await _unitOfWork.SaveAsync();
        }

       

        public async Task<UserCard> GetUserCardByUserId(string userId)
        {
          return await _unitOfWork.UserCards.GetUserCardByUserId(userId);
              

        }

        public async Task InitializeUserCard(string userId)
        {
            var userCard = new UserCard() { UserId = userId };
           await _unitOfWork.UserCards.CreateAsync(userCard);
           await _unitOfWork.SaveAsync();
        }
    }
}
