using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.UI.Controllers
{
    public class UserPageController : Controller
    {
        public IActionResult UserPage()
        {
            return View();
        }
    }
}
