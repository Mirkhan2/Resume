using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Resume.Application.Services.Interfaces;
using Resume.Domain.ViewModels.CustomerFeedBack;
using Resume.Infra.Data.Context;

namespace Resume.Application.Services.Implementations
{
    public class CustomerFeedBackService : ICustomerFeedBackService
    {
        #region Constructor
        private readonly AppDbContext _context;

        public CustomerFeedBackService(AppDbContext context)
        {
            _context = context;
        }

        #endregion

        async Task<List<CustomerFeedBackViewModel>> ICustomerFeedBackService.GetCustomerFeedBackForIndex()
        {
            List<CustomerFeedBackViewModel> customerFeedBacks = await _context.customerFeedBacks
                .OrderBy(s => s.Order)
                .Select(s => new CustomerFeedBackViewModel()
                {
                    Order = s.Order,
                    Avatar = s.Avatar,
                    Description = s.Description,
                    Id  = s.Id,
                    Name = s.Name
                })
                .ToListAsync();
            return customerFeedBacks;
        }
    }
}
