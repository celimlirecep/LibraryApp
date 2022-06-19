

using LibraryApp.API.DTO;
using LibraryApp.API.Identity;
using LibraryApp.API.Models;
using LibraryApp.BL.Abstract;
using LİbraryApp.EL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.API.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {

        private readonly IBookService _bookService;
        private readonly IUserCardService _userCardService;
        private UserManager<User> _userManager;

        public BooksController(IBookService bookService, IUserCardService userCardService, UserManager<User> userManager)
        {
            _bookService = bookService;
            _userCardService = userCardService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _bookService.GetAll();
            if (books == null)
            {
                return NotFound();
            }
            var bookDTOList=DTOBookModel(books);
            return Ok(bookDTOList);
        }

        [HttpPost("addbook")]
        public async Task<IActionResult> AddToUserCard(BookAddModel model)
        {
            if (model.BookId<1)
            {
                return BadRequest();
            }
           
            string result= await _userCardService.AddToCard(model.UserId, model.BookId);
            return Ok(result);

        }
        [HttpPost("getmylibrary")]
        public async Task<IActionResult> GetUsersbook(UserInfo model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            UserCard userCard=   await _userCardService.GetUserCardByUserId(model.UserId);
            if (userCard==null)
            {
                return NotFound();
            }
            List<UserLibraryModel> libraryModels = new List<UserLibraryModel>();
            foreach (var bookReserve in userCard.BookReserves)
            {
                if (bookReserve.Status)
                {
                    continue;
                }
                var librarymodel = new UserLibraryModel()
                {
                    BookId=bookReserve.BookId,
                    BarrowingDate=bookReserve.BarrowingDate,
                    BookDeadline=bookReserve.BookDeadline,
                    BookImage=bookReserve.Book.BookImage,
                    BookName=bookReserve.Book.BookName,
                };
                libraryModels.Add(librarymodel);
            }
          
          
            return Ok(libraryModels);
        }
        [HttpPut("deliverybook")]
        public async Task<IActionResult> DeliveryBook(DeliveryBookModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
        
            await _userCardService.DeleteToCard(model.UserId, model.BookId);
            return Ok();
        }
        [HttpPost("readbookshistory")]
        public async Task<IActionResult> ReadBooksHistory(UserInfo userInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
         var userCard=   await _userCardService.GetUserCardByUserId(userInfo.UserId);
            if (userCard==null)
            {
                return NotFound();
            }
            List<ReadBookHistoryModel> model = new List<ReadBookHistoryModel>();
            foreach (var bookReserve in userCard.BookReserves)
            {
                if (bookReserve.Status)
                {
                    ReadBookHistoryModel readBook = new ReadBookHistoryModel()
                    {
                        BookId = bookReserve.BookId,
                        BarrowingDate = bookReserve.BarrowingDate,
                        BookImage = bookReserve.Book.BookImage,
                        BookName = bookReserve.Book.BookName,
                        DelivertDate = bookReserve.DeliveryDate
                    };
                    model.Add(readBook);
                }
            }


            return Ok(model);

        }

        private List<BookModel> DTOBookModel(List<Book> books)
        {
            List<BookModel> bookModels = new List<BookModel>();
            foreach (var book in books)
            {
                var bookmodel = new BookModel()
                {
                    BookId = book.BookId,
                    BookImage=book.BookImage,
                    BookName=book.BookName,
                    CurrentStock=book.CurrentStock
                };
                bookModels.Add(bookmodel);
            }
            return bookModels;
        }

    }
}
