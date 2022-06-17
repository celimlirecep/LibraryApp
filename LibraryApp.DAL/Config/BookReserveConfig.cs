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
    public class BookReserveConfig : IEntityTypeConfiguration<BookReserve>
    {
        public void Configure(EntityTypeBuilder<BookReserve> builder)
        {
            builder.HasKey(b => b.BookReserveId);
        }
    
    }
}
