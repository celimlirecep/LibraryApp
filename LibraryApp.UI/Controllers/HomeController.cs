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
                var jsonEmployee = JsonConvert.SerializeObject(bookId);
                StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
                httpclient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                using (var response = await httpclient.PostAsync("https://localhost:4200/api/Books/addbook", content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        //eklendi mesajı verilecek
                    }
                }
              
            }
            return Redirect("/");
        }


    }
}
