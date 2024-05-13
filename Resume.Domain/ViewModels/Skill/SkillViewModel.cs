using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Domain.ViewModels.Skil
{
    public  class SkillViewModel
    {
        public long Id { get; set; }


        [Display(Name = "عنوان")]
        public string Title { get; set; }


        [Display(Name = "درصد")]
        public string Percent { get; set; }


        [Display(Name = "الویت")]
        public int Order { get; set; }

    }
}
