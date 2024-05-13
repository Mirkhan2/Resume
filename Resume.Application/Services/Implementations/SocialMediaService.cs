using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Resume.Application.Services.Interfaces;
using Resume.Domain.ViewModels.SocialMedia;
using Resume.Infra.Data.Context;

namespace Resume.Application.Services.Implementations
{
    public  class SocialMediaService : ISocialMediaService
    {
        #region Constructor
        private readonly AppDbContext _context;
        public SocialMediaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<SocialMediaViewModel>> GetAllSocialMedia()
        {
            List<SocialMediaViewModel> socialmedia = await _context.SocialMedias
                 .OrderBy(s => s.Order)
                 .Select(s => new SocialMediaViewModel()
                 {
                     Icon = s.Icon,
                     Id = s.Id,
                     Link = s.Link,
                     Order = s.Order,
                 })
                 .ToListAsync();

            return socialmedia;
        }
        #endregion
    }
}
