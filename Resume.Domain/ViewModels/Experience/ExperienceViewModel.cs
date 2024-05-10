using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Domain.ViewModels.Experience
{
    public class ExperienceViewModel
    {
        public long Id { get; set; }


        [Display(Name = "عنوان")]
        public string Title { get; set; }


        [Display(Name = "تاریخ شروع")]
        public string StartDate { get; set; }


        [Display(Name = "تاریخ پایان")]
        public string EndDate { get; set; }


        [Display(Name = "توضیحات")]
        public string Description { get; set; }


        [Display(Name = "الویت")]
        public int Order { get; set; }

    }
}
