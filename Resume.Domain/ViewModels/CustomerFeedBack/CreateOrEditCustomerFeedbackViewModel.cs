using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Domain.ViewModels.CustomerFeedBack
{
    public class CreateOrEditCustomerFeedbackViewModel
    {
        public long Id { get; set; }


        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string Title { get; set; }


        [Display(Name = "تاریخ شروع")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MinLength(4, ErrorMessage = "{0} نمیتواند کمتر از {1} کاراکتر باشد")]
        [MaxLength(4, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string StartDate { get; set; }


        [Display(Name = "تاریخ پایان")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MinLength(4, ErrorMessage = "{0} نمیتواند کمتر از {1} کاراکتر باشد")]
        [MaxLength(4, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string EndDate { get; set; }


        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(1000, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string Description { get; set; }


        [Display(Name = "الویت")]
        public int Order { get; set; }
    }
}
