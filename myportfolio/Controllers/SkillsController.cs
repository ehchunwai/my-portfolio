using Microsoft.AspNetCore.Mvc;
using myportfolio.Models;
using myportfolio.Modules;
using System.Collections.Generic;

namespace myportfolio.Controllers
{
    public class SkillsController : Controller
    {
        SkillsService _skillsService = null;
        AboutService _aboutService = null;

        public SkillsController(SkillsService skillsService, AboutService aboutService)
        {
            _skillsService = skillsService;
            _aboutService = aboutService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("skills/p-index")]
        public IActionResult p_index()
        {

            var profile = _aboutService.GetProfileByUid(Program._userUid);
            List<SkillModel> list = _skillsService.GetSkillList();

            Dictionary<TypeValues, List<SkillModel>> dict = new Dictionary<TypeValues, List<SkillModel>>();
            foreach (var item in list)
            {
                if (!dict.ContainsKey(item.Type))
                {
                    dict.Add(item.Type, new List<SkillModel>());
                }
                dict[item.Type].Add(item);
            }

            ViewData["Skills"] = dict;
            ViewData["Profile"] = profile;

            return PartialView("~/Views/Skills/Index.cshtml");
        }
    }
}
