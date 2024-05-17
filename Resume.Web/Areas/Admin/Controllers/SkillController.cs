using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Resume.Application.Services.Interfaces;
using Resume.Domain.ViewModels.Skill;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class SkillController : AdminBaseController
    {
        #region Constructor

        private readonly ISkillService _skillService;
        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;

        }
        #endregion
        public async Task<IActionResult> Index()
        {
            return View(await _skillService.GetAllSkills());
        }
        public async Task<IActionResult> LoadSkillFormModal(long id)
        {
            CreateOrEditSkillViewModel result = await _skillService.FillCreateOrEditSkillViewModel(id);
            return PartialView("_SkillFormModalPartial",result);


        }
        public async Task<IActionResult> SubmitSkillFormModal(CreateOrEditSkillViewModel skill)
        {
            var result = await _skillService.CreateOrEditSkill(skill);
            if (result) return new  JsonResult(new { status = "Success" });

            return new JsonResult(new { status = "Error" });
            
        }
        public async Task<IActionResult> DeleteSkill(long id)
        {
            var result = await _skillService.DeleteSkill(id);

            if (result) return new JsonResult(new { status = "Success" });

            return new JsonResult(new { status = "Error" });
        }

        
    }
}
