using Microsoft.AspNetCore.Mvc;
using myportfolio.Modules;
using System.Text;

namespace myportfolio.Controllers
{
    public class AboutUsController : Controller
    {
        AboutService _aboutService = null;

        public AboutUsController(AboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("aboutus/p-index")]
        public IActionResult p_index()
        {
            var result = _aboutService.GetProfileByUid(Program._userUid);
            ViewData["Age"] = result.Age;
            var yearsInService = _aboutService.GetYearsInService(Program._userUid);
            ViewData["YearsInService"] = yearsInService;
            ViewData["Profile"] = result;
            StringBuilder sb = new StringBuilder();
            foreach (var item in result.LanguageList)
            {
                sb.Append(item);
                sb.Append(", ");
            }

            ViewData["Language"] = sb.ToString().Substring(0, sb.ToString().Length - 2);
            return PartialView("~/Views/AboutUs/Index.cshtml");
        }


    }
}
