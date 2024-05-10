using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resume.Domain.ViewModels.Education;
using Resume.Domain.ViewModels.Experience;

namespace Resume.Domain.ViewModels.Page
{
    public class ResumePageViewModel
    {
        public List<EducationViewModel> Educations { get; set; }
        public List<ExperienceViewModel> Experiences { get; set; }
    }
}
