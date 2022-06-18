using LİbraryApp.EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.BL.Abstract
{
    public interface IUserCardService
    {
        public Task InitializeUserCard(string userId);
         UserCard GetUserCardByUserId(string userId);
        Task AddToCard(string userId, int bookId);
    }
}
