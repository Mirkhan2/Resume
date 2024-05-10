using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resume.Domain.ViewModels.CustomerLogo;

namespace Resume.Application.Services.Interfaces
{
    public interface ICustomerLogoService
    {
        Task<List<CustomerLogoViewModel>> GetCustomerLogosForIndexPage();
    }
}
