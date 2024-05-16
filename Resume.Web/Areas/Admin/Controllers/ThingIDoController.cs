using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Resume.Application.Services.Interfaces;
using Resume.Domain.ViewModels.ThingIDo;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class ThingIDoController : AdminBaseController   
    {
        #region Constructor
        private readonly IThingIDoService _thingIDOService;

        public ThingIDoController(IThingIDoService thingIDOService)
        {
            _thingIDOService = thingIDOService;
        }
        #endregion


        #region List
        public async Task<IActionResult> Index()
        {
            return View(await _thingIDOService.GetAllThingIDoForIndex());
        }
        #endregion


        public async Task<IActionResult> LoadThingIDoFormModal(long id)
        {
            CreateOrEditThingIDoViewModel result = await _thingIDOService.FillCreateOrEditThingIDoViewModel(id);

            return PartialView("_ThingIDoFormModalPartial", result);
        }
        public async Task<IActionResult> SubmitThingIDoFormModal(CreateOrEditThingIDoViewModel thingIDo)
        {
            var result = await _thingIDOService.CreateOrEditThingIDo(thingIDo);

            if (result) return new JsonResult(new {status = "Success"});

            return new JsonResult(new { status = " Error"});
        }
        public async Task<IActionResult> DeleteThingIDO(long id)
        {
            var result = await _thingIDOService.DeleteThingIDo(id);
            if (true) return new JsonResult ( new { status = "Success" } );

            return new JsonResult(new { status = "Error" });
            

            
        }
    }
}
