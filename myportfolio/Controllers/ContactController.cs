using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myportfolio.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("contact/p-index")]
        public IActionResult p_index()
        {
            return PartialView("~/Views/Contact/Index.cshtml");
        }
    }
}
