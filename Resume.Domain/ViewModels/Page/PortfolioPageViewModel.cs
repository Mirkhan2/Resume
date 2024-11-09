using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resume.Domain.ViewModels.Portofolio;

namespace Resume.Domain.ViewModels.Page
{
    public class PortfolioPageViewModel
    {
        public List<PortofolioViewModel> Portfolios { get; set; }
        public List<PortofolioCategoryViewModel> PortfolioCategories { get; set; }
    }
}
