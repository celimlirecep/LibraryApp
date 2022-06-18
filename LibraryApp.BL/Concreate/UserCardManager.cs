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

        public async Task AddToCard(string userId, int bookId)
        {
            var userCard = GetUserCardByUserId(userId);
            if (userCard != null)
            {
                var index = userCard.BookReserves.FindIndex(i => i.BookId == bookId);
                if (index>0)
                {
                    userCard.BookReserves.Add(new BookReserve() { 
                    BookId=bookId,
                    BarrowingDate=DateTime.Now,
                    UserCardId=userCard.UserCardId,
                    BookDeadline=DateTime.Now.AddDays(7)
                    });
                    await _unitOfWork.SaveAsync();
                }
            }
        }

        public  UserCard GetUserCardByUserId(string userId)
        {
            return  _unitOfWork.UserCards.GetUserCardByUserId(userId);
        }

        public async Task InitializeUserCard(string userId)
        {
            var userCard = new UserCard() { UserId = userId };
           await _unitOfWork.UserCards.CreateAsync(userCard);
           await _unitOfWork.SaveAsync();
        }
    }
}
