using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Resume.Application.Services.Interfaces;

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


        #endregion

        public async Task<IActionResult>  Index()
        {
            return View(await _thingIDOService.GetAllThingIDoForIndex());
        }
    }
}
