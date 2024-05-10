using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Resume.Application.Services.Interfaces;
using Resume.Domain.ViewModels.Page;

namespace Resume.Web.Controllers
{
    public class ResumeController : Controller
    {
        #region Constructor
        private readonly IEducationService _educationService;
        private readonly IExperienceService _experienceService;
        public ResumeController(IEducationService educationService, IExperienceService experienceService)
        {
            _educationService = educationService;
            _experienceService = experienceService;

        }


        #endregion
        public async Task<IActionResult> Index()
        {
            ResumePageViewModel model = new ResumePageViewModel()
            {
                Educations = await _educationService.GetAllEducations(),
                Experiences = await _experienceService.GetAllExperiences()

            };
            return View(model);
        }
    }
}

