using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Resume.Web.ViewComponents
{
    public class MetaTagViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("MetaTag");
        }
    }
}
