using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resume.Domain.ViewModels.SocialMedia;

namespace Resume.Application.Services.Interfaces
{
    public  interface ISocialMediaService
    {
        Task<List<SocialMediaViewModel>> GetAllSocialMedia();
    }
}
