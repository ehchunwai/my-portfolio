using Microsoft.AspNetCore.Mvc;
using myportfolio.Modules;

namespace myportfolio.Controllers
{
    public class TestimonialController : Controller
    {
        TestimonialService _testimonialService = null;

        public TestimonialController(TestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("testimonial/p-index")]
        public IActionResult p_index()
        {
            var result = _testimonialService.GetTestimonialList(Program._userUid);
            ViewData["Testimonial"] = result;

            return PartialView("~/Views/Testimonial/Index.cshtml");
        }
    }
}
