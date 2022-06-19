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
    public class BookManager : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Book>> GetAll()
        {
            return await _unitOfWork.Books.GetAll();
        }

        
    }
}
