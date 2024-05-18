using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Resume.Application.Services.Interfaces;
using Resume.Domain.ViewModels.Portofolio;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class PortfolioCategoryController : AdminBaseController
    {
        #region Constructor
        private readonly IPortofolioService _portfolioService;
        public PortfolioCategoryController(IPortofolioService portofolioService)
        {
            _portfolioService = portofolioService;
        }
        #endregion
        public async Task<IActionResult> Index()
        {
            return View(await _portfolioService.GetAllPortfolioCategories());

        }
        public async Task<IActionResult> LoadPortfolioCategoryForModal(long id)
        {
            CreateOrEditPortfolioCategoryViewModel result = await _portfolioService.FillCreateOrEditPortfolioCategoryViewModel(id);
            return PartialView("_PortfolioCategoryForModalPartial" , result);
        }
        public async Task<IActionResult> SubmitPortfolioCategoryFormModal(CreateOrEditPortfolioCategoryViewModel portfolioCategory)
        {
            var result = await _portfolioService.CreateOrEditPortfolioCategory(portfolioCategory);

            if (result) return new JsonResult(new { status = "Success" });

            return new JsonResult(new { status = "Error" });

        }
        public async Task<IActionResult> DeletePortfolioCategory(long id)
        {
            var result = await _portfolioService.DeletePortfolioCategory(id);
            if (result) return new JsonResult(new { status = "Success" });

            return new JsonResult(new { status = "Error" });
        }



    }
}
