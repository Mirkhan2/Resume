using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Resume.Application.Services.Interfaces;
using Resume.Domain.Models;
using Resume.Domain.ViewModels.Information;
using Resume.Domain.ViewModels.SocialMedia;
using Resume.Domain.ViewModels.ViewComponent;

namespace Resume.Web.ViewComponents
{
    public class SideBarViewComponent : ViewComponent
    {
        #region Constructor

        private readonly ISocialMediaService _socialMediaService;
        private readonly IInformationService _informationService;

        public SideBarViewComponent(ISocialMediaService socialMediaService, IInformationService informationService)
        {
            _socialMediaService = socialMediaService;
            _informationService = informationService;   
        }

        //public List<SocialMediaViewModel> SocialMedias { get; private set; }

        //private InformationViewModel information;


        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            SideBarViewModel model = new SideBarViewModel()
            {
                SocialMedias = await _socialMediaService.GetAllSocialMedia(),
                information = await _informationService.GetInformation()
            };

            return View("SideBar", model);
        }

    }
}
