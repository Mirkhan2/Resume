using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resume.Domain.ViewModels.CustomerFeedBack;

namespace Resume.Application.Services.Interfaces
{
    public interface ICustomerFeedBackService
    {
        Task<List<CustomerFeedBackViewModel>> GetCustomerFeedBackForIndex();
    }
}
