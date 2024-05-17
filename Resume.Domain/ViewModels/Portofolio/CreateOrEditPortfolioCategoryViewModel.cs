using System.ComponentModel.DataAnnotations;


namespace Resume.Domain.ViewModels.Portofolio
{
    public class CreateOrEditPortfolioCategoryViewModel
    {

        [Key]
        public long Id { get; set; }


        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string Title { get; set; }


        [Display(Name = "تاریخ شروع")]
        [MaxLength(1000, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string Link { get; set; }


        [Display(Name = "تصویر")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string Image { get; set; }

        public string Name { get; set; }


        [Display(Name = "توضیح تصویر")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string ImageAlt { get; set; }


        [Display(Name = "الویت")]
        public int Order { get; set; } = 0;
    }
}
