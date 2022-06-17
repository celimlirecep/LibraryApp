using LibraryApp.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LibraryApp.UI.Controllers
{
    public class HomeController : Controller
    {
       

        public IActionResult HomePage()
        {
            return View();
        }
        
        public async Task<IActionResult> GetAllBooksFromRestFullApi()
        {
            var books = new List<BookModel>();
            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync("https://localhost:4200/api/Books"))
                {
                    string contentResponce = await response.Content.ReadAsStringAsync();
                    books = JsonConvert.DeserializeObject<List<BookModel>>(contentResponce).ToList();
                }
            }
            return View(books);
        }

        public IActionResult BarrowAbook()
        {
            return View();
        }


    }
}
