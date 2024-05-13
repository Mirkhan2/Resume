using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Resume.Application.Services.Interfaces;
using Resume.Domain.ViewModels.Information;
using Resume.Infra.Data.Context;

namespace Resume.Application.Services.Implementations
{
    public class InformationService : IInformationService
    {
        #region Constructor
        private readonly AppDbContext _context;

        public InformationService(AppDbContext context)
        {
            _context = context;
        }
        #endregion

        public async Task<InformationViewModel> GetInformation()
        {
            InformationViewModel information = await _context.information
                .Select(i => new InformationViewModel()
                {

                    Address = i.Address,
                    Avatar = i.Avatar,
                    DateOfBirth = i.DateOfBirth,
                    Email = i.Email,
                    Id = i.Id,
                    Job = i.Job,
                    Name = i.Name,
                    Phone = i.Phone,
                    ResumeFile = i.ResumeFile,
                    MapSrc = i.MapSrc
                })
                .FirstOrDefaultAsync();


            if (information == null)
            {
                return new InformationViewModel();
            }

            return information;
        }

    }
}
