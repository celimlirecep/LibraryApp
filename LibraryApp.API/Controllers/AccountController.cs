using LibraryApp.API.Identity;
using LibraryApp.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
      
    

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
         
        }

        
        [AllowAnonymous]
        [HttpPost("login")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {

            
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                return NotFound();
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);
            if (result.Succeeded)
            {
                return Ok(user);
            }
            return BadRequest();
        }

        [AllowAnonymous]
        [HttpPost("register")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var user = new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
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
