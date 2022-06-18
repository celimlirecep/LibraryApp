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
           
            using (var httpclient = new HttpClient())
            {
                
                var jsonEmployee = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
                using (var response = await httpclient.PostAsync("https://localhost:4200/api/account/login",content))
                {
                 
                 
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonString = await response.Content.ReadAsStringAsync();
                        HttpContext.Session.SetString("Authorization", jsonString);
                       
                        var head = HttpContext.Request.Headers;
                        //var token = HttpContext.Session.GetString("Authorization").ToString();
                        return Redirect("/");
                   
                    }
                }
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
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
                        return View();
                    }
                }
            }
            return View();

        }

      
        public async Task<IActionResult> LogOut()
        {
            using (var httpclient = new HttpClient())
            {
                var token = HttpContext.Session.GetString("Authorization").ToString();
                httpclient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                using (var response = await httpclient.GetAsync("https://localhost:4200/api/account/logout"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return Redirect("/");
                    }
                }
            }
            return Redirect("/");
        }
    }
}
