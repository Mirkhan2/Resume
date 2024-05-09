using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resume.Domain.ViewModels.ThingIDo;

namespace Resume.Application.Services.Interfaces
{
    public interface IThingIDoService
	{
		List<ThingIDoListViewModel> GetAllThingIDoForIndex();
	}
}
