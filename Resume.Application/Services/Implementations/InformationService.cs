using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
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
            InformationViewModel information = await _context.Informations
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

        public async Task<Information> GetInformationModel()
        {
            return await _context.Informations.FirstOrDefaultAsync();
            //return await _context.Informations.FirstOrDefaultAsync() ;
            
        }

        public async Task<CreateOrEditInformationViewModel> FillCreateOrEditInformationViewModel()
        {
            Information information = await GetInformationModel();

            if (information == null) return new CreateOrEditInformationViewModel() { Id = 0 };

            return new CreateOrEditInformationViewModel()
            {
                //Id = Information.Id,
                //Address = information.Address,
                //Avatar = information.Avatar,
                //DateOfBirth = information.DateOfBirth,
                //Email = information.Email,
                //Job = information.Job,
                //MapSrc = information.MapSrc,
                //Name = information.Name,
                //Phone = information.Phone,
                //ResumeFile = information.ResumeFile
            };
        }

        public Task<bool> CreateOrEditInformation(CreateOrEditInformationViewModel information)
        {



            if (information.Id == 0)
            {
                var newInformation = new Information()
                {
                    Address = information.Address,
                    Avatar = information.Avatar,
                    DateOfBirth = information.DateOfBirth,
                    Email = information.Email,
                    Job = information.Job,
                    MapSrc = information.MapSrc,
                    Name = information.Name,
                    Phone = information.Phone,
                    ResumeFile = information.ResumeFile
                };

                await _context.Information.AddAsync(newInformation);
                await _context.SaveChangesAsync();
                return true;
            }

            //Information currentInformation = await GetInformationModel();

            //currentInformation.Address = information.Address;
            //currentInformation.Avatar = information.Avatar;
            //currentInformation.DateOfBirth = information.DateOfBirth;
            //currentInformation.Email = information.Email;
            //currentInformation.Job = information.Job;
            //currentInformation.MapSrc = information.MapSrc;
            //currentInformation.Name = information.Name;
            //currentInformation.Phone = information.Phone;
            //currentInformation.ResumeFile = information.ResumeFile;

            //_context.information.Update(currentInformation);
            //await _context.SaveChangesAsync();
            //return true;
        }
    }
}
