using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resume.Application.Extension;
using Resume.Application.Generator;
using Resume.Application.Services.Interfaces;
using Resume.Application.Static_Tools;
using Resume.Domain.ViewModels.Portofolio;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class PortfolioController : AdminBaseController
    {

        #region Constructor

        private readonly IPortofolioService _portofolioService;
        public PortfolioController(IPortofolioService portofolioService)
        {
                _portofolioService = portofolioService;

        }

        #endregion

        public async Task<IActionResult>  Index()
        {
            return View(await _portofolioService.GetAllPortfolios());
        }
        public async Task<IActionResult> LoadPortfolioForModal(long id)
        {
            CreateOrEditPortflioViewModel result = await _portofolioService.FillCreateOrEditPortfolioViewModal(id);
            return PartialView( "_PartialFormModalPartial"  ,result);
        }
        public async Task<IActionResult> SubmitPortfolioFormModal(CreateOrEditPortflioViewModel portfolio)
        {
            //if (await _portofolioService.CreateOrEditPortfolio(portfolio))
            //    return new JsonResult(new { status = "Succcess" });
            //return new JsonResult(new { status = "Error" });
            var result = await _portofolioService.CreateOrEditPortfolio(portfolio);
            if (result) return new JsonResult(new { status = "Success" });
           
            return new JsonResult(new { status = "Error" });
        }
        public async Task<IActionResult> DeletePortfolioFeedback(long id)
        {
            var result = await _portofolioService.DeleteOrEditPortfolio(id);
            if (result) return new JsonResult(new { status = "Success" });
            return new JsonResult(new {status = "Error"});

        }
        [HttpPost]
        public async Task<IActionResult> UploadPortfolioResumeAjax(IFormFile file)
        {
            if (file != null)
            {
                if (Path.GetExtension(file.FileName) == ".png" || Path.GetExtension(file.FileName) == ".jpeg" || Path.GetExtension(file.FileName) == ".jpg")
                {
                    var imageName = CodeGenerator.GeneratUniqCode() + Path.GetExtension(file.FileName);
                    await file.AddImmageAjaxToServer(imageName, FilePaths.PortfolioServer);

                    return new JsonResult(new { status = "Success", imageName });
                }
                else
                {
                    return new JsonResult(new { status = "Error" });

                }

            }
            else
            {
                return new JsonResult(new { status = "Error" });

            }
        
    }

    }
}
