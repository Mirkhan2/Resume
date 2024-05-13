using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resume.Domain.ViewModels.Information;

namespace Resume.Application.Services.Interfaces
{
    public interface IInformationService
    {
        Task<InformationViewModel> GetInformation();
    }
}
