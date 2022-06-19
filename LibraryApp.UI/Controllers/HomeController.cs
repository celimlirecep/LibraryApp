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
        public async Task<IActionResult> GetAllBooksFromRestFullApi()
        {
           
            if (!IsAuthentic())
            {
                TempData["Message"] = CreateMessage("Dikkat", "Lütfen Sisteme Giriş Yapınız", "warning");
                return Redirect("/");
            }
            var books = new List<BookModel>();
            using (var httpclient = new HttpClient())
            {
                ResponseMessage message = GetCurrentUserInfo();
                httpclient.DefaultRequestHeaders.Add("Authorization", "Bearer " + message.Token);
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
            if (bookId<1)
            {
                TempData["Message"] = CreateMessage("Dikkat", "Lütfen eklemek istediğiniz kitabı seçiniz", "warning");
                return RedirectToAction("GetAllBooksFromRestFullApi");
            }
            
            using (var httpclient = new HttpClient())
            {
                ResponseMessage message = GetCurrentUserInfo();
                httpclient.DefaultRequestHeaders.Add("Authorization", "Bearer " + message.Token);
             
                AddBookModel model = new AddBookModel()
                {
                    BookId = bookId,
                    UserId = message.UserId
                };
                var jsonEmployee = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
                
                using (var response = await httpclient.PostAsync("https://localhost:4200/api/Books/addbook", content))
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    
                    TempData["Message"] = CreateMessage("Dikkat", $"{jsonString}", "warning");
                    
                }
              
            }
            return RedirectToAction("GetAllBooksFromRestFullApi");
        }
        public async Task<IActionResult> GetUserLibrary()
        {
            if (!IsAuthentic())
            {
                TempData["Message"] = CreateMessage("Dikkat", $"Lütfen Sisteme giriş yapınız", "warning");
                return Redirect("/");
            }
            using (var httpclient = new HttpClient())
            {
                ResponseMessage message = GetCurrentUserInfo();
                httpclient.DefaultRequestHeaders.Add("Authorization", "Bearer " + message.Token);
                var jsonEmployee = JsonConvert.SerializeObject(message);
                StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
                using (var response = await httpclient.PostAsync("https://localhost:4200/api/Books/getmylibrary", content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var librayBooks = new List<LibraryBookModel>();
                        string contentResponse = await response.Content.ReadAsStringAsync();
                        librayBooks = JsonConvert.DeserializeObject<List<LibraryBookModel>>(contentResponse).ToList();
                        return View(librayBooks);
                    }
                }

            }
            return RedirectToAction("GetAllBooksFromRestFullApi");
        }
        public async Task<IActionResult> ReadBooksHistory()
        {
            if (!IsAuthentic())
            {
                TempData["Message"] = CreateMessage("Dikkat", $"Lütfen Sisteme giriş yapınız", "warning");
                return Redirect("/");
            }
            using (var httpclient = new HttpClient())
            {
                ResponseMessage message = GetCurrentUserInfo();
                httpclient.DefaultRequestHeaders.Add("Authorization", "Bearer " + message.Token);
                var jsonEmployee = JsonConvert.SerializeObject(message);
                StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
                using (var response = await httpclient.PostAsync("https://localhost:4200/api/Books/readbookshistory/",content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var UserReadBooks = new List<ReadBookHistoryModel>();
                        string contentResponse = await response.Content.ReadAsStringAsync();
                        UserReadBooks = JsonConvert.DeserializeObject<List<ReadBookHistoryModel>>(contentResponse).ToList();
                        return View(UserReadBooks);
                    }
                }

            }
            return RedirectToAction("GetAllBooksFromRestFullApi");

        }
        public async Task<IActionResult> DeleteBookFromUserLibrary(int bookId)
        {
            if (bookId<1)
            {
                TempData["Message"] = CreateMessage("Dikkat", $"Lütfen teslim etmek istediğiniz kitabı seçiniz", "warning");
                return RedirectToAction("GetUserLibrary");
            }
            using (var httpclient = new HttpClient())
            {
                ResponseMessage responseMessage = GetCurrentUserInfo();
                httpclient.DefaultRequestHeaders.Add("Authorization", "Bearer " + responseMessage.Token);
                
                AddBookModel model = new AddBookModel()
                {
                    BookId = bookId,
                    UserId = responseMessage.UserId
                };
                var jsonEmployee = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");

                using (var response = await httpclient.PutAsync("https://localhost:4200/api/Books/deliverybook", content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        TempData["Message"] = CreateMessage("Dikkat", $"Kitap teslim etme işleminiz başarıyla gerçekleşmiştir", "success");
                    }
                    else
                    {
                        TempData["Message"] = CreateMessage("Dikkat", $"Kitap teslim etme işleminiz başarısız olmuştur, Lütfen yetkililerle ilitişime geçiniz", "success");
                    }
                }

            }

            return RedirectToAction("GetUserLibrary");

        }

        private ResponseMessage GetCurrentUserInfo()
        {
            return new ResponseMessage()
            {
                Token = HttpContext.Session.GetString("Authorization").ToString(),
                UserId =  HttpContext.Session.GetString("UserId").ToString()
            };
            
        }
        private static string CreateMessage(string title, string message, string alertType)
        {
            var msg = new AlertMessage()
            {
                Title = title,
                Message = message,
                AlertType = alertType
            };
            return JsonConvert.SerializeObject(msg);
        }
        private bool IsAuthentic()
        {
            if (HttpContext.Session.GetString("Authorization") == null || HttpContext.Session.GetString("Authorization") == string.Empty)
            {
                return false;
            }
            return true;
        }



    }
}
