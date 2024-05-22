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

        public async Task<CustomerFeedBack> GetCustomerFeedbackById(long id)
        {
            return await _context.CustomerFeedBacks.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<CustomerFeedBackViewModel>> GetCustomerFeedbackForIndex()
        {
            List<CustomerFeedBackViewModel> customerFeedbacks = await _context.CustomerFeedBacks
                .OrderBy(c => c.Order)
                .Select(c => new CustomerFeedBackViewModel()
                {
                    Order = c.Order,
                    Avatar = c.Avatar,
                    Description = c.Description,
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();

            return customerFeedbacks;
        }


        public async Task<bool> CreateOrEditCustomerFeedback(CreateOrEditCustomerFeedbackViewModel customerFeedback)
        {
            if (customerFeedback.Id == 0)
            {
                var newCustomerFeedback = new CustomerFeedBack()
                {
                    Avatar = customerFeedback.Avatar,
                    Description = customerFeedback.Description,
                    Name = customerFeedback.Name,
                    Order = customerFeedback.Order
                };

                await _context.CustomerFeedBacks.AddAsync(newCustomerFeedback);
                await _context.SaveChangesAsync();

                return true;
            }


            CustomerFeedBack currentCustomerFeedback = await GetCustomerFeedbackById(customerFeedback.Id);

            if (currentCustomerFeedback == null) return false;

            currentCustomerFeedback.Avatar = customerFeedback.Avatar;
            currentCustomerFeedback.Description = customerFeedback.Description;
            currentCustomerFeedback.Name = customerFeedback.Name;
            currentCustomerFeedback.Order = customerFeedback.Order;

            _context.CustomerFeedBacks.Update(currentCustomerFeedback);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<CreateOrEditCustomerFeedbackViewModel> FillCreateOrEditCustomerFeedbackViewModel(long id)
        {
            if (id == 0) return new CreateOrEditCustomerFeedbackViewModel() { Id = 0 };

            CustomerFeedBack customerFeedback = await GetCustomerFeedbackById(id);

            if (customerFeedback == null) return new CreateOrEditCustomerFeedbackViewModel() { Id = 0 };

            return new CreateOrEditCustomerFeedbackViewModel()
            {
                Id = customerFeedback.Id,
                Avatar = customerFeedback.Avatar,
                Description = customerFeedback.Description,
                Name = customerFeedback.Name,
                Order = customerFeedback.Order
            };

        }

        public async Task<bool> DeleteCustomerFeedback(long id)
        {
            CustomerFeedBack customerFeedback = await GetCustomerFeedbackById(id);

            if (customerFeedback == null) return false;

            _context.CustomerFeedBacks.Remove(customerFeedback);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
