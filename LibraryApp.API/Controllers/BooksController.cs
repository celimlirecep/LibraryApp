

using LibraryApp.API.Identity;
using LibraryApp.API.Models;
using LibraryApp.BL.Abstract;
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
            return Ok(books);
        }

        [HttpPost("addbook")]
        public async Task<IActionResult> AddToUserCard(BookAddModel model)
        {
            if (model.BookId<1)
            {
                return BadRequest();
            }
     
            await _userCardService.AddToCard(model.UserId, model.BookId);
            return Ok();

        }

    }
}
