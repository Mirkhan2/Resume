using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resume.Domain.Models;
using Resume.Domain.ViewModels.ThingIDo;

namespace Resume.Application.Services.Interfaces
{
    public interface IThingIDoService
	{
		Task<ThingIDo> GetThingIDoById(long id);

		Task<List<ThingIDoListViewModel>> GetAllThingIDoForIndex();

		Task<bool> CreateOrEditThingIDo(CreateOrEditThingIDoViewModel thingIDo);
        Task<CreateOrEditThingIDoViewModel> FillCreateOrEditThingIDoViewModel(long id);
		Task<bool> DeleteThingIDo(long id);


    }
}
