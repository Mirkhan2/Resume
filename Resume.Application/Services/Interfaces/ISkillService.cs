using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resume.Domain.ViewModels.Skil;

namespace Resume.Application.Services.Interfaces
{
    public interface ISkillService
    {
        Task<List<SkillViewModel>> GetAllSkills();
    }
}
