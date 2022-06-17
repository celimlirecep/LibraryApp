using LibraryApp.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.DAL.Concreate.EfCore
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryContext _context;

        public UnitOfWork(LibraryContext context)
        {
            _context = context;
        }

        private EfCoreBookRepository _bookRepository;
        private EfCoreUserCardRepository _userCardRepository;


        public IBookRepository Books => _bookRepository=_bookRepository??new EfCoreBookRepository(_context);

        public IUserCardRepository UserCards => _userCardRepository = _userCardRepository ?? new EfCoreUserCardRepository(_context);

       

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
