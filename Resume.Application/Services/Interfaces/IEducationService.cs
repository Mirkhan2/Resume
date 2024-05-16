using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resume.Domain.Models;
using Resume.Domain.ViewModels.Education;

namespace Resume.Application.Services.Interfaces
{
    public interface IEducationService
    {
        Task<Education> GetEducationById(long id);
        Task<List<EducationViewModel>> GetAllEducations();
        Task<CreateOrEditEducationViewModel> FillCreateOrEditEditEducationViewModel(long id);
        Task<bool> CreateOrEditEducation(CreateOrEditEducationViewModel education);
        Task<bool> DeleteEducation(long id);

    }
}
