
using System.ComponentModel.DataAnnotations;

namespace Resume.Domain.ViewModels.Skill
{
    public class CreateOrEditSkillViewModel
    {
        [Key]
        public long Id { get; set; }


        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string Title { get; set; }


        [Display(Name = "درصد")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MinLength(1, ErrorMessage = "{0} نمیتواند کمتر از {1} کاراکتر باشد")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string Percent { get; set; }


        [Display(Name = "الویت")]
        public int Order { get; set; } = 0;
    }
}
