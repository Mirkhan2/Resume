using System.Collections.Generic;
using Resume.Domain.ViewModels.CustomerFeedBack;
using Resume.Domain.ViewModels.CustomerLogo;
using Resume.Domain.ViewModels.ThingIDo;

namespace Resume.Domain.ViewModels.Page
{
	public class IndexPageViewModel
	{
        public List<ThingIDoListViewModel> ThingIDoList { get; set; }
        public List<CustomerFeedBackViewModel> CustomerFeedBackList { get; set; }
        public List<CustomerLogoViewModel> CustomerLogoList { get; set; }
    }
}
