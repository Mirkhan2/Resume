using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Domain.ViewModels.Portofolio
{
    public  class PortofolioCategoryViewModel
    {

        public long Id { get; set; }


        [Display(Name = "عنوان")]
        public string Title { get; set; }


        [Display(Name = "نام")]
        public string Name { get; set; }


        [Display(Name = "الویت")]
        public int Order { get; set; }
    }
}
