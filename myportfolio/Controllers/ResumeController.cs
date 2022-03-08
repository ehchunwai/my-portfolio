using Microsoft.AspNetCore.Mvc;
using myportfolio.Modules;

namespace myportfolio.Controllers
{
    public class ResumeController : Controller
    {
        private WorkExperienceService _workExperienceService = null;

        public ResumeController(WorkExperienceService workExperienceService)
        {
            _workExperienceService = workExperienceService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("resume/p-index")]
        public IActionResult p_index()
        {
            _workExperienceService.UpdateCurrentWorkExperience();

            var result = _workExperienceService.GetWorkExperienceList(Program._userUid);

            ViewData["Milestone"] = result;

            return PartialView("~/Views/Resume/Index.cshtml");
        }
    }
}
