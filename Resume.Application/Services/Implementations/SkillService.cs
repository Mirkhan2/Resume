using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Resume.Application.Services.Interfaces;
using Resume.Domain.ViewModels.Skil;
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



    }
}
