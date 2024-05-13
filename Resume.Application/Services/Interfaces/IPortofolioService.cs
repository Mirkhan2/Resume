using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resume.Domain.ViewModels.Portofolio;

namespace Resume.Application.Services.Interfaces
{
    public interface IPortofolioService
    {
        Task<List<PortofolioViewModel>> GetAllPortofolio();
        Task<List<PortofolioCategoryViewModel>> GetAllPortofolioCategories();
    }
}
