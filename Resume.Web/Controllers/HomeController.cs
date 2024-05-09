using System;
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

        public HomeController(IThingIDoService thingIDoService)
        {
			_thingIDoService = thingIDoService;    
        }

        #endregion
        public IActionResult Index()
		{
			IndexPageViewModel model = new IndexPageViewModel()
			{
				ThingIDoList = _thingIDoService.GetAllThingIDoForIndex()
			};

			return View(model);
		}

	
	}
}
