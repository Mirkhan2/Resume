using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resume.Domain.ViewModels.Experience;

namespace Resume.Application.Services.Interfaces
{
    public  interface IExperienceService
    {
        Task<List<ExperienceViewModel>> GetAllExperiences();
    }
}
