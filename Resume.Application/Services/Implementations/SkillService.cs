using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Resume.Application.Services.Interfaces;
using Resume.Domain.Models;
using Resume.Domain.ViewModels.Skil;
using Resume.Domain.ViewModels.Skill;
using Resume.Infra.Data.Context;

namespace Resume.Application.Services.Implementations
{
    public class SkillService : ISkillService
    {
        #region Constructor 
        private readonly AppDbContext _context;
        public SkillService(AppDbContext context)
        {
            _context = context;
        }

        #endregion

        public async Task<Skill> GetSkillById(long id)
        {
            return await _context.Skills.FirstOrDefaultAsync(s => s.Id == id);
        }
        public async Task<List<SkillViewModel>> GetAllSkills()
        {
            List<SkillViewModel> skills = await _context.Skills
                .OrderBy(s => s.Order)
                .Select(s => new SkillViewModel()
                {
                    Id = s.Id,
                    Order = s.Order,
                    Percent = s.Percent,
                    Title = s.Title
                })
                .ToListAsync();


            return skills;
        }

        public async Task<CreateOrEditSkillViewModel> FillCreateOrEditSkillViewModel(long id)
        {
           if (id == 0) return new CreateOrEditSkillViewModel();
           
           Skill skill = await GetSkillById(id);
//vergiss nicht bitte id==0
            if (skill == null) return new CreateOrEditSkillViewModel();

            return new CreateOrEditSkillViewModel
            {
                Id = skill.Id,
                Order = skill.Order,
                Percent = skill.Percent,
                Title = skill.Title


            };
        }

        public async Task<bool> CreateOrEditSkill(CreateOrEditSkillViewModel skill)
        {
            if (skill.Id == 0)
            {
                var newSkill = new Skill()
                {
                    Id = skill.Id,
                    Order = skill.Order,
                    Percent = skill.Percent,
                    Title = skill.Title
                };
                await _context.Skills.AddAsync(newSkill);
                 await _context.SaveChangesAsync();
                return true;
            }
            Skill currentSkill = await GetSkillById(skill.Id);

            if (currentSkill == null) return false;

            currentSkill.Order = skill.Order;
            currentSkill.Percent = skill.Percent;
            currentSkill.Title = skill.Title;
            
            _context.Skills.Update(currentSkill);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteSkill(long id)
        {
            
            Skill skill = await GetSkillById(id);
            if (skill == null) return false;
            

            _context.Skills.Remove(skill);
            await _context.SaveChangesAsync();
            return true;

        }
    }
}
