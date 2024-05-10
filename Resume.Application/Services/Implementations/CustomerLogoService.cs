using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Resume.Application.Services.Interfaces;
using Resume.Domain.ViewModels.CustomerLogo;
using Resume.Infra.Data.Context;

namespace Resume.Application.Services.Implementations
{
    public class CustomerLogoService : ICustomerLogoService
    {
        #region Contructor
        private readonly AppDbContext _context;

        public CustomerLogoService(AppDbContext context)
        {
            _context = context;
        }
        #endregion


        public async Task<List<CustomerLogoViewModel>> GetCustomerLogosForIndexPage()
        {
            List<CustomerLogoViewModel> customerlogos = await _context.CustomerLogos
                .OrderBy(c => c.Order)
                .Select(c => new CustomerLogoViewModel()
                {
                    Id = c.Id,
                    Link = c.Link,
                    LogoAlt = c.LogoAlt,
                    Logo = c.Logo,
                    Order = c.Order,
                })
                .ToListAsync();

            return customerlogos;
        }

    }
}
