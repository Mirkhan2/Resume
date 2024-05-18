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
        #region portfolio

        Task<Portofolio> GetPortfolioById(long id);
        Task<List<PortofolioViewModel>> GetAllPortfolios();
        Task<CreateOrEditPortflioViewModel> FillCreateOrEditPortfolioViewModal(long id);
        Task<bool> CreateOrEditPortfolio(CreateOrEditPortflioViewModel portfolio);

        Task<bool> DeleteOrEditPortfolio(long id);

        #endregion



        #region Portfolio Category
        Task<PortfolioCategory> GetPortfolioCategoryById(long id);
        Task<List<PortofolioCategoryViewModel>> GetAllPortfolioCategories();
        Task<CreateOrEditPortfolioCategoryViewModel> FillCreateOrEditPortfolioCategoryViewModel(long id);
        Task<bool> CreateOrEditPortfolioCategory(CreateOrEditPortfolioCategoryViewModel portfolioCategory);
        Task<bool> DeletePortfolioCategory(long id);
        #endregion

    }
}
