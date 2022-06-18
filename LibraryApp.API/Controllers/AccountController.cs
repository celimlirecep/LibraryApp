using LibraryApp.API.Identity;
using LibraryApp.API.JWT;
using LibraryApp.API.Models;
using LibraryApp.BL.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LibraryApp.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private IUserCardService _userCardService;
      
    

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IUserCardService userCardService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userCardService = userCardService;
         
        }

        
        [AllowAnonymous]
        [HttpPost("login")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (model==null)
            {
                throw new NullReferenceException("Register model is null");
            }
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                return BadRequest();
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);
            if (result.Succeeded)
            {
            
                var userToken = JWTAuthenticationManager.Authenticate(user.Id);
                return Ok(userToken);
            }
            return NotFound();
        }
        // /api/account/register
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                return BadRequest();
            }
            var user = new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
               await _userCardService.InitializeUserCard(user.Id);
                return Ok(user);
            }

            return BadRequest();
        }

        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            
            await _signInManager.SignOutAsync();
            return NoContent();
        }

      

    }
}
