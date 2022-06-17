using LİbraryApp.EL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.DAL.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b=>b.BookId);
            builder.Property(b => b.BookName).IsRequired().HasMaxLength(20);
            builder.Property(b => b.BookStock).IsRequired();
        }
    
    }
}
