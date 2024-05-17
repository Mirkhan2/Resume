using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resume.Domain.Models;
using Resume.Domain.ViewModels.Portofolio;

namespace Resume.Application.Services.Interfaces
{
    public interface IPortofolioService
    {
        Task<List<PortofolioViewModel>> GetAllPortfolios();


        #region Portfolio Category
        Task<PortfolioCategory> GetPortfolioCategoryById(long id);
        Task<List<PortofolioCategoryViewModel>> GetAllPortfolioCategories();
        Task<CreateOrEditPortfolioCategoryViewModel> FillCreateOrEditPortfolioCategoryViewModel(long id);
        Task<bool> CreateOrEditPortfolioCategory(CreateOrEditPortfolioCategoryViewModel portfolioCategory);
        Task<bool> DeletePortfolioCategory(long id);
        #endregion

    }
}
