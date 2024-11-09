using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Resume.Application.Services.Interfaces;
using Resume.Domain.ViewModels.Page;
using Resume.Domain.ViewModels.Portofolio;

namespace Resume.Web.Controllers
{
    public class PortofolioController : Controller
    {
        #region Constructor
        private readonly IPortofolioService _porfolioService;

        public PortofolioController(IPortofolioService porfolioService)
        {
            _porfolioService = porfolioService;
        }
        #endregion


        public async Task<IActionResult> Index()
        {

            PortfolioPageViewModel model = new PortfolioPageViewModel()
            {
                Portfolios = await _porfolioService.GetAllPortfolios(),
                PortfolioCategories = await _porfolioService.GetAllPortfolioCategories()
            };

            return View(model);
        }
    }
}
