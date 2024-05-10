using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resume.Domain.ViewModels.Education;

namespace Resume.Application.Services.Interfaces
{
    public interface IEducationService
    {
        Task<List<EducationViewModel>> GetAllEducations();
    }
}
