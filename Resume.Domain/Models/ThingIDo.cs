using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Domain.Models
{
	public class ThingIDo
	{
		#region Properties
		[Key]
		public long Id { get; set; }


		[Display(Name = "آیکون")]
		[MaxLength(50, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
		public string Icon { get; set; }


		[Display(Name = "عنوان")]
		[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
		[MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
		public string Title { get; set; }


		[Display(Name = "توضیحات")]
		[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
		[MaxLength(1000, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
		public string Description { get; set; }


		[Display(Name = "عرض ستون آیتم")]
		[Range(4, 12, ErrorMessage = "مقدار وارد شده باید بین 4 تا 12 باشد.")]
		public int ColumnLg { get; set; } = 6;


		[Display(Name = "الویت")]
		public int Order { get; set; } = 0;

		#endregion  
	}
	}
