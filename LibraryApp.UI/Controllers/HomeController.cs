using LibraryApp.UI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.UI.Controllers
{
    public class HomeController : Controller
    {
       

        public IActionResult HomePage()
        {
            return View();
        }

        //allows the user to fetch all the books
        public async Task<IActionResult> GetAllBooksFromRestFullApi()
        {
           
            if (HttpContext.Session.GetString("Authorization") == null)
            {
                return Redirect("/");
            }
            var books = new List<BookModel>();
            using (var httpclient = new HttpClient())
            {
                var token = HttpContext.Session.GetString("Authorization").ToString();
                httpclient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                using (var response = await httpclient.GetAsync("https://localhost:4200/api/Books"))
                {
                    string contentResponse = await response.Content.ReadAsStringAsync();
                    books = JsonConvert.DeserializeObject<List<BookModel>>(contentResponse).ToList();
                }
            }
            return View(books);
        }
         [HttpPost]
        public async Task<IActionResult> AddBookToUserLibrary(int bookId)
        {
            
            using (var httpclient = new HttpClient())
            {
                var token = HttpContext.Session.GetString("Authorization").ToString();
                httpclient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var userId = HttpContext.Session.GetString("UserId").ToString();
                AddBookModel model = new AddBookModel()
                {
                    BookId = bookId,
                    UserId = userId
                };
                var jsonEmployee = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
                
                using (var response = await httpclient.PostAsync("https://localhost:4200/api/Books/getusersbook", content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        //eklendi mesajı verilecek
                    }
                }
              
            }
            return RedirectToAction("GetAllBooksFromRestFullApi");
        }
       
        public async Task<IActionResult> GetUserLibrary()
        {
            using (var httpclient = new HttpClient())
            {
                var token = HttpContext.Session.GetString("Authorization").ToString();
                httpclient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var userId = HttpContext.Session.GetString("UserId").ToString();
                var jsonEmployee = JsonConvert.SerializeObject(new {userId=userId });
                StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");

                using (var response = await httpclient.PostAsync("https://localhost:4200/api/Books/getmylibrary", content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        
                        return View();
                    }
                }

            }
            return RedirectToAction("GetAllBooksFromRestFullApi");
        }


    }
}
