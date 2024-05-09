using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resume.Application.Services.Interfaces;
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
        public List<ThingIDoListViewModel> GetAllThingIDoForIndex()
		{
			List<ThingIDoListViewModel> thingIdos = _context
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
				.ToList();

			return thingIdos;
		}
	}
}
