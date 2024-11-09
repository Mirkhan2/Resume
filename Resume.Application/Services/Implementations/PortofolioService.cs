using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Resume.Application.Services.Interfaces;
using Resume.Domain.Models;
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




        #region portfolio



        public async Task<Portofolio> GetPortfolioById(long id)
        {
           return await _context.Portfolios.FirstOrDefaultAsync(p => p.Id == id);
        }


        public async Task<List<PortofolioViewModel>> GetAllPortfolios()
        {
            List<PortofolioViewModel> portofolios = await _context.Portfolios
                .OrderBy(x => x.Order)
                .Select(x => new PortofolioViewModel()
                {
                    Id = x.Id,
                    Image = x.Image,
                    ImageAlt = x.ImageAlt,
                    Link = x.Link,
                    Order = x.Order,
                    PortfolioCategoryName = x.PortfolioCategory.Name,
                    Title = x.Title

                })
                .ToListAsync();

            return portofolios;

        }



        public async Task<CreateOrEditPortflioViewModel> FillCreateOrEditPortfolioViewModal(long id)
        {
            if (id == 0) return new CreateOrEditPortflioViewModel() {
                Id = 0 ,
                PortfolioCategories = await GetAllPortfolioCategories() 
            };
            
            Portofolio portofolio = await GetPortfolioById(id);

            if(portofolio == null) return new CreateOrEditPortflioViewModel()
            {
                Id = 0,

                PortfolioCategories = await GetAllPortfolioCategories()
            };

            return new CreateOrEditPortflioViewModel()
            {
                Id = portofolio.Id,
                Image = portofolio.Image,
                ImageAlt = portofolio.ImageAlt,
                Link = portofolio.Link,
                Order = portofolio.Order,
                Title = portofolio.Title,
                PortfolioCategoryId = portofolio.PortfolioCategoryId,
                PortfolioCategories = await GetAllPortfolioCategories()
            };
        }


        public async Task<bool> CreateOrEditPortfolio(CreateOrEditPortflioViewModel portfolio)
        {
            if(portfolio.Id == 0)
            {
                var newPortfolio = new Portofolio()
                {
                    Image = portfolio.Image,
                    ImageAlt = portfolio.ImageAlt,
                    Link = portfolio.Link,
                    Order = portfolio.Order,
                    Title = portfolio.Title,
                    PortfolioCategoryId = portfolio.PortfolioCategoryId
                };

                await _context.Portfolios.AddAsync(newPortfolio);
                await _context.SaveChangesAsync();
                return true;
            }
            Portofolio currentPortfolio = await GetPortfolioById(portfolio.Id);
            if (currentPortfolio == null) return false;

            currentPortfolio.Image= portfolio.Image;
            currentPortfolio.ImageAlt = portfolio.ImageAlt;
            currentPortfolio.Link = portfolio.Link;
            currentPortfolio.Order = portfolio.Order;
            currentPortfolio.Title = portfolio.Title;
            currentPortfolio.PortfolioCategoryId = portfolio.PortfolioCategoryId;

            _context.Portfolios.Update(currentPortfolio);
            await _context.SaveChangesAsync();

            return true;
    
        }

        public async Task<bool> DeleteOrEditPortfolio(long id)
        {
            Portofolio portofolio = await GetPortfolioById(id);
            if (portofolio == null) return false;

            _context.Portfolios.Remove(portofolio);
            await _context.SaveChangesAsync();
            return true;
        }


        #endregion

        #region Portfolio Category
        public async Task<PortfolioCategory> GetPortfolioCategoryById(long id)
        {
            return await _context.PortfolioCategories.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<PortofolioCategoryViewModel>> GetAllPortfolioCategories()
        {
            List<PortofolioCategoryViewModel> portfolioCategories = await _context.PortfolioCategories
                .OrderBy(pc => pc.Order)
                .Select(pc => new PortofolioCategoryViewModel()
                {
                    Id = pc.Id,
                    Name = pc.Name,
                    Order = pc.Order,
                    Title = pc.Title
                })
                .ToListAsync();

            return portfolioCategories;
        }

        public async Task<CreateOrEditPortfolioCategoryViewModel> FillCreateOrEditPortfolioCategoryViewModel(long id)
        {
            if (id == 0) return new CreateOrEditPortfolioCategoryViewModel() { Id = 0 };

            PortfolioCategory portfolioCategory = await GetPortfolioCategoryById(id);

            if (portfolioCategory == null) return new CreateOrEditPortfolioCategoryViewModel() { Id = 0 };

            return new CreateOrEditPortfolioCategoryViewModel()
            {
                Id = portfolioCategory.Id,
                Name = portfolioCategory.Name,
                Order = portfolioCategory.Order,
                Title = portfolioCategory.Title
            };
        }

        public async Task<bool> CreateOrEditPortfolioCategory(CreateOrEditPortfolioCategoryViewModel portfolioCategory)
        {

            if (portfolioCategory.Id == 0)
            {
                var newPortfolioCategory = new PortfolioCategory()
                {
                    Name = portfolioCategory.Name,
                    Order = portfolioCategory.Order,
                    Title = portfolioCategory.Title
                };

                await _context.PortfolioCategories.AddAsync(newPortfolioCategory);
                await _context.SaveChangesAsync();
                return true;
            }

            PortfolioCategory currentPortfolioCategory = await GetPortfolioCategoryById(portfolioCategory.Id);

            if (currentPortfolioCategory == null) return false;

            currentPortfolioCategory.Name = portfolioCategory.Name;
            currentPortfolioCategory.Order = portfolioCategory.Order;
            currentPortfolioCategory.Title = portfolioCategory.Title;

            _context.PortfolioCategories.Update(currentPortfolioCategory);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeletePortfolioCategory(long id)
        {
            PortfolioCategory portfolioCategory = await GetPortfolioCategoryById(id);

            if (portfolioCategory == null) return false;

            _context.PortfolioCategories.Remove(portfolioCategory);
            await _context.SaveChangesAsync();

            return true;
        }
        #endregion
    }
}
