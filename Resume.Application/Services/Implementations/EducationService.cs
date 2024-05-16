using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Resume.Application.Services.Interfaces;
using Resume.Domain.Models;
using Resume.Domain.ViewModels.Education;
using Resume.Infra.Data.Context;

namespace Resume.Application.Services.Implementations
{
    public class EducationService : IEducationService
    {

        #region Constructor 

        private readonly AppDbContext _context;
        public EducationService(AppDbContext context)
        {
            _context = context;
        }
        #endregion

        public async Task<Education> GetEducationById(long id)
        {
            return await _context.Educations.FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<List<EducationViewModel>> GetAllEducations()
        {
            List<EducationViewModel> educations = await _context.Educations
                .OrderBy(c => c.Order)
                .Select(c => new EducationViewModel()
                {
                    Description = c.Description,
                    EndDate = c.EndDate,
                    Id = c.Id,
                    StartDate = c.StartDate,
                    Title = c.Title,
                    Order = c.Order
                })
                .ToListAsync();

            return educations;
        }

        public async Task<CreateOrEditEducationViewModel> FillCreateOrEditEditEducationViewModel(long id)
        {
           if(id == 0) return new CreateOrEditEducationViewModel() { Id = 0};

            Education education = await GetEducationById(id);

            if (education == null) return new CreateOrEditEducationViewModel() { Id = 0 };

            return new CreateOrEditEducationViewModel()
            {
                Id = education.Id,
                Description = education.Description,
                EndDate = education.EndDate,
                Order = education.Order,
                StartDate = education.StartDate,
                Title = education.Title,


            };
        }

        public async Task<bool> CreateOrEditEducation(CreateOrEditEducationViewModel education)
        {
            if (education.Id == 0)
            {
                var newEducation = new Education()
                {
                    Description = education.Description,
                    EndDate = education.EndDate,
                    Order = education.Order,
                    StartDate = education.StartDate,
                    Title = education.Title,

                };
                await _context.Educations.AddAsync(newEducation);
                await _context.SaveChangesAsync();
                return true;
            }
            Education currentEducation = await GetEducationById(education.Id);

            if (currentEducation == null) { return false; }

            currentEducation.Description = education.Description;
            currentEducation.EndDate = education.EndDate;
            currentEducation.Order = education.Order;
            currentEducation.StartDate = education.StartDate;
            currentEducation.Title = education.Title;

            _context.Educations.Update(currentEducation);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteEducation(long id)
        {
            Education education = await GetEducationById(id);
            if (education == null) return false;
            
            _context.Educations.Remove(education);
            await _context.SaveChangesAsync();
            return true;

        }
    }
}
