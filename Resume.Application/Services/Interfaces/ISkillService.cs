using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resume.Domain.Models;
using Resume.Domain.ViewModels.Skil;
using Resume.Domain.ViewModels.Skill;

namespace Resume.Application.Services.Interfaces
{
    public interface ISkillService
    {
        Task<Skill> GetSkillById(long id);
        Task<List<SkillViewModel>> GetAllSkills();
        Task<CreateOrEditSkillViewModel> FillCreateOrEditSkillViewModel(long id);   
        Task<bool> CreateOrEditSkill(CreateOrEditSkillViewModel skill); 
        Task<bool> DeleteSkill(long id);
    }
}
