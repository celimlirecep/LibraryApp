using LİbraryApp.EL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.DAL.Config
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book() { BookId=1,BookName="Dinle Küçük Adam",BookImage= "https://i2.milimaj.com/i/milliyet/75/750x0/61778f6a932151bfc8037f8f.jpg",BookStock=5,CurrentStock=5 },
                new Book() { BookId = 2, BookName = "Nar Ağacı", BookImage = "https://i2.milimaj.com/i/milliyet/75/750x0/61778f6a932151bfc8037f8f.jpg", BookStock = 5, CurrentStock = 8 },
                new Book() { BookId = 3, BookName = "Savaşçı", BookImage = "https://i2.milimaj.com/i/milliyet/75/750x0/61778f6a932151bfc8037f8f.jpg", BookStock = 5, CurrentStock = 5 },
                new Book() { BookId = 4, BookName = "Doğmamış Çocuğa Mektup", BookImage = "https://i2.milimaj.com/i/milliyet/75/750x0/61778f6a932151bfc8037f8f.jpg", BookStock = 5, CurrentStock = 3 },
                new Book() { BookId = 5, BookName = "Küçük Kara Balık", BookImage = "https://i2.milimaj.com/i/milliyet/75/750x0/61778f6a932151bfc8037f8f.jpg", BookStock = 5, CurrentStock = 10 },
                new Book() { BookId = 6, BookName = "Uygarlıkların Batışı", BookImage = "https://i2.milimaj.com/i/milliyet/75/750x0/61778f6a932151bfc8037f8f.jpg", BookStock = 5, CurrentStock = 7 }

                );
        }
    }
}
