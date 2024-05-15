using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Resume.Application.Services.Interfaces;
using Resume.Domain.Models;
using Resume.Domain.ViewModels.ThingIDo;
using Resume.Infra.Data.Context;

namespace Resume.Application.Services.Implementations
{
    public class ThingIDoService : IThingIDoService
	{
		#region Constructor

		private readonly AppDbContext _context;

        public ThingIDoService(AppDbContext context)
        {
			_context = context;


		}

        #endregion

        public async Task<ThingIDo> GetThingIDoById(long id)
        {
			return await _context.ThingIDos.FirstOrDefaultAsync(  t => t.Id == id);
        }

        public async  Task<List<ThingIDoListViewModel>> GetAllThingIDoForIndex()
		{
			List<ThingIDoListViewModel> thingIdos = await _context
				.ThingIDos
				.OrderBy(t => t.Order)
				.Select(t => new ThingIDoListViewModel
				{
					Id = t.Id,
					ColumnLg = t.ColumnLg,
					Description = t.Description,
					Order = t.Order,
					Icon = t.Icon,
					Title = t.Title

				})
				.ToListAsync();

			return thingIdos;
		}

        public async Task<bool> CreateOrEditThingIDo(CreateOrEditThingIDoViewModel thingIDo)
        {	
			if(thingIDo.Id == 0)
			{
				var newThingIDo = new ThingIDo()
				{
					ColumnLg = thingIDo.ColumnLg,
					Description = thingIDo.Description,
					Order = thingIDo.Order,
					Icon = thingIDo.Icon,
					Title = thingIDo.Title

				};

				await _context.ThingIDos.AddAsync(newThingIDo);
				await _context.SaveChangesAsync();
				return true;

			}
			ThingIDo currentThingIdo = await GetThingIDoById(thingIDo.Id);

			if (currentThingIdo == null) return false;

			currentThingIdo.ColumnLg = thingIDo.ColumnLg;
			currentThingIdo.Description = thingIDo.Description;
			currentThingIdo.Icon = thingIDo.Icon;
			currentThingIdo.Order = thingIDo.Order;
			currentThingIdo.Title = thingIDo.Title;

			_context.ThingIDos.Update(currentThingIdo);
			await _context.SaveChangesAsync();

			return true;
        }

        public Task<CreateOrEditThingIDoViewModel> FillCreateOrEditThingIDoViewModel(long id)
        {

            if (id == 0) return new CreateOrEditThingIDoViewModel() { Id = 0 };

            ThingIDo thingIDo = await GetThingIDoById(id);

            if (thingIDo == null) return new CreateOrEditThingIDoViewModel() { Id = 0 };

            return new CreateOrEditThingIDoViewModel()
            {
                Id = thingIDo.Id,
                ColumnLg = thingIDo.ColumnLg,
                Description = thingIDo.Description,
                Icon = thingIDo.Icon,
                Order = thingIDo.Order,
                Title = thingIDo.Title
            };
        }
    }
}
