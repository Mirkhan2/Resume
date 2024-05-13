using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Resume.Application.Services.Interfaces;
using Resume.Domain.ViewModels.Portofolio;
using Resume.Infra.Data.Context;

namespace Resume.Application.Services.Implementations
{
    public  class PortofolioService : IPortofolioService
    {
        #region Constructor
        private readonly AppDbContext _context;
        public PortofolioService(AppDbContext context)
        {
            _context = context;
        }

        #endregion
        public async Task<List<PortofolioViewModel>> GetAllPortofolio()
        {
            List<PortofolioViewModel> portofolios = await _context.Portofolios
                .OrderBy(x => x.Order)
                .Select(x => new PortofolioViewModel()
                {
                    Id = x.Id,
                    Image= x.Image,
                    ImageAlt= x.ImageAlt,
                    Link= x.Link,
                    Order= x.Order,
                    PortfolioCategoryName = x.PortfolioCategory.Name,
                    Title= x.Title

                })
                .ToListAsync();

            return portofolios;
           
        }

        public async Task<List<PortofolioCategoryViewModel>> GetAllPortofolioCategories()
        {
           List<PortofolioCategoryViewModel> portofoliosCatagories = await _context.PortfolioCategories
                .OrderBy(pc => pc.Order)
                .Select(pc => new PortofolioCategoryViewModel()
                {
                    Id = pc.Id,
                    Name = pc.Name,
                    Order= pc.Order,
                    Title= pc.Title
                })
                .ToListAsync();
            return portofoliosCatagories;
        }
    }
}
