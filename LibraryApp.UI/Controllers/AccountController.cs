using LibraryApp.UI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.UI.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = CreateMessage("Başarısız", "Lütfen geçerli bir e-posta adresi veya şifre girişi yapınız", "danger");
                return View(model);
            }
            using (var httpclient = new HttpClient())
            {
                var jsonEmployee = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
                using (var response = await httpclient.PostAsync("https://localhost:4200/api/account/login",content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonString = await response.Content.ReadAsStringAsync();
                        ResponseMessage values = JsonConvert.DeserializeObject<ResponseMessage>(jsonString);
                        HttpContext.Session.SetString("Authorization", values.Token);
                        HttpContext.Session.SetString("UserId", values.UserId);
                        TempData["Message"] = CreateMessage("Başarılı", "Giriş işlemi başarılı bir şekilde gerçekleşmiştir", "success");
                        return Redirect("/");
                    }
                }
            }
            TempData["Message"] = CreateMessage("Başarısız", "Giriş işlemi başarısız olmuştur", "danger");
            return View(model);
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = CreateMessage("Başarısız", "Lütfen tüm alanları doğru bir şekilde doldurunuz", "danger");
                return View(model);
            }
            using (var httpclient = new HttpClient())
            {
                var jsonEmployee = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
                using (var response = await httpclient.PostAsync("https://localhost:4200/api/account/register", content))
                {
                    if (response.IsSuccessStatusCode)
                    {

                        string jsonString = await response.Content.ReadAsStringAsync();
                        HttpContext.Session.SetString("UserToken", jsonString);
                        return Redirect("/");
                    }
                }
            }
            return View();

        }

      
        public  IActionResult LogOut()
        {
            HttpContext.Session.SetString("Authorization", string.Empty);
            return Redirect("/");
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
    }
}
