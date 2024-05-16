using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Resume.Application.Services.Interfaces;
using Resume.Domain.Models;
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




        public async  Task<CustomerFeedBack> GetCustomerFeedbackById(long id)
        {
                return await _context.customerFeedBacks.FirstOrDefaultAsync(c => c.Id == id);
        }

        
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

        public async Task<bool> CreateOrEditCustomerFeedback(CustomerFeedBackViewModel customerFeedBack)
        {
            if (customerFeedBack.Id == 0)
            {
                var newCustomerFeedback = new CustomerFeedBack()
                {
                    Avatar = customerFeedBack.Avatar,
                    Description = customerFeedBack.Description,
                   Order = customerFeedBack.Order,
                    Name = customerFeedBack.Name

                };
                await _context.customerFeedBacks.AddAsync(newCustomerFeedback);
                await _context.SaveChangesAsync();
                return true;


            }
            CustomerFeedBack currentCustomerFeedback = await GetCustomerFeedbackById(customerFeedBack.Id);
            if (currentCustomerFeedback == null) return false;

            currentCustomerFeedback.Avatar = customerFeedBack.Avatar;   
            currentCustomerFeedback.Description = customerFeedBack.Description;
            currentCustomerFeedback.Order = customerFeedBack.Order;
            currentCustomerFeedback.Name    = customerFeedBack.Name;

            _context.customerFeedBacks.Update(currentCustomerFeedback);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<CreateOrEditCustomerFeedbackViewModel> FillCreateOrEditCustomerFeedbackViewModel(long id)
        {
            if (id == 0) return new CreateOrEditCustomerFeedbackViewModel() { Id = 0 };

            CustomerFeedBack customerFeedBack = await GetCustomerFeedbackById(id);


            if (customerFeedBack == null) return new CreateOrEditCustomerFeedbackViewModel() { Id = 0 };

            return new CreateOrEditCustomerFeedbackViewModel()
            {
                Id = customerFeedBack.Id,
                Description = customerFeedBack.Description,
                Order   = customerFeedBack.Order,
                //avatar = customerFeedBack.Avatar,

            };

        }

        public async Task<bool> DeleteCustomerFeedback(long id)
        {
            CustomerFeedBack customerFeedBack = await GetCustomerFeedbackById(id);
            if (customerFeedBack == null) return false;
            _context.customerFeedBacks.Remove(customerFeedBack);
            await _context.SaveChangesAsync();
            return true;

            
        }
    }
}
