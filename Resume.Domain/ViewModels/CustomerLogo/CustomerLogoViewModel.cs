using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Domain.ViewModels.CustomerLogo
{
    public class CustomerLogoViewModel
    {

        [Key]
        public long Id { get; set; }


        [Display(Name = "لوگو")]

        public string Logo { get; set; }


        [Display(Name = "توضیحات لوگو")]
   
        public string LogoAlt { get; set; }


        [Display(Name = "لینک")]
       
        public string Link { get; set; }


        [Display(Name = "الویت")]
        public int Order { get; set; }
    }
}
