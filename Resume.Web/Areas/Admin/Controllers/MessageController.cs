using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Resume.Application.Services.Interfaces;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class MessageController : AdminBaseController
    {
        #region Constructor
        private readonly IMessageService _messageService;
        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        #endregion

        public async Task<IActionResult> Index()
        {
            return View(await _messageService.GetAllMessages());
        }

        public async Task<IActionResult> DeleteMessage(long id)
        {
            var result = await _messageService.DeleteMessage(id);

            if (result) return new JsonResult(new { status = " Success" });

            return new JsonResult(new { status = " Error" });

        }
    }
}
