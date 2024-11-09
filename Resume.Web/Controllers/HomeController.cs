using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Resume.Application.Services.Interfaces;
using Resume.Domain.ViewModels.Page;
using Resume.Web.Models;

namespace Resume.Web.Controllers
{
	public class HomeController : Controller
	{
		#region Constructor

		private readonly IThingIDoService _thingIDoService;
		private readonly ICustomerFeedbackService _customerFeedBackService;
		private readonly ICustomerLogoService _customerLogoService;	

        public HomeController(IThingIDoService thingIDoService, ICustomerFeedbackService customerFeedBackService, ICustomerLogoService customerLogoService)
        {
            _thingIDoService = thingIDoService;
            _customerFeedBackService = customerFeedBackService;
            _customerLogoService = customerLogoService;
        }

        #endregion
        public async Task<IActionResult>  Index()
		{
			IndexPageViewModel model = new IndexPageViewModel()
			{
				ThingIDoList = await _thingIDoService.GetAllThingIDoForIndex(),
				CustomerFeedBackList = await _customerFeedBackService.GetCustomerFeedbackForIndex(),
				CustomerLogoList = await _customerLogoService.GetCustomerLogosForIndexPage()
			};

			return View(model);
		}

	
	}
}
