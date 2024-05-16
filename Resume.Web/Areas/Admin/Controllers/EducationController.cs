using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Resume.Application.Services.Interfaces;
using Resume.Domain.ViewModels.Education;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class EducationController : AdminBaseController
    {
        #region Constructor
        private readonly IEducationService _educationService;

        public EducationController(IEducationService educationService)
        {
            _educationService = educationService;
        }

        #endregion
        public async Task<IActionResult> Index()
        {
            return View(await _educationService.GetAllEducations());
        }

        public async Task<IActionResult> LoadEducationFormModal(long id)
        {
            CreateOrEditEducationViewModel result = await _educationService.FillCreateOrEditEditEducationViewModel(id);

            return PartialView("_EducationFormModal PArtial", result);
        }
        public async Task<IActionResult> SubmitEducationFormModal(CreateOrEditEducationViewModel education)
        {
            var result = await _educationService.CreateOrEditEducation(education);

            if (result) return new JsonResult(new { status = " Success" });

            return new JsonResult(new { status = " Eror" });

        }
        public async Task<IActionResult> DeleteEducation(long id)
        {
            var result = await _educationService.DeleteEducation(id);


            if (result) return new JsonResult(new { status = " Success" });

            return new JsonResult(new { status = " Eror" });
        }
    }
}
