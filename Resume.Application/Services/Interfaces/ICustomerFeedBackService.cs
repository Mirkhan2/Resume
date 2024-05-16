using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resume.Domain.Models;
using Resume.Domain.ViewModels.CustomerFeedBack;

namespace Resume.Application.Services.Interfaces
{
    public interface ICustomerFeedBackService
    {
        Task<CustomerFeedBack> GetCustomerFeedbackById(long id);
        Task<List<CustomerFeedBackViewModel>> GetCustomerFeedBackForIndex();

        Task<bool> CreateOrEditCustomerFeedback(CustomerFeedBackViewModel customerFeedBack);
        Task<CreateOrEditCustomerFeedbackViewModel> FillCreateOrEditCustomerFeedbackViewModel(long id);  
        Task<bool> DeleteCustomerFeedback(long id);
    }
}
