using Microsoft.AspNetCore.Mvc;
using myportfolio.Modules;

namespace myportfolio.Controllers
{
    public class ProjectsController : Controller
    {
        ProjectService _projectService = null;

        public ProjectsController(ProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet("projects/index")]
        public IActionResult index()
        {
            return View("~/Views/Projects/Index.cshtml");
        }

        [HttpGet("projects/p-index")]
        public IActionResult p_index()
        {
            return PartialView("~/Views/Projects/Index.cshtml");
        }

        [HttpGet("projects/main")]
        public IActionResult main()
        {
            var result = _projectService.GetProjectListByUid(Program._userUid);
            ViewData["ProjectList"] = result;
            return View("~/Views/Projects/_Main.cshtml");
        }
    }
}
