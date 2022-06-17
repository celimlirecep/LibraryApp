using LibraryApp.DAL.Config;
using LİbraryApp.EL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.DAL.Concreate.EfCore
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<BookReserve> BookReserves { get; set; }
        public DbSet<UserCard> UserCards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfig());
            modelBuilder.ApplyConfiguration(new BookReserveConfig());
            
           modelBuilder.Seed();

        }
    }
}
