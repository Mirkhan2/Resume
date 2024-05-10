using Microsoft.Extensions.DependencyInjection;
using Resume.Application.Services.Implementations;
using Resume.Application.Services.Interfaces;

namespace Resume.Infra.IoC
{
	public class DependencyContainers
	{
		public static void  RegisterServices(IServiceCollection services)
		{
			services.AddScoped<IThingIDoService, ThingIDoService>();
            services.AddScoped<ICustomerFeedBackService, CustomerFeedBackService>();
			services.AddScoped<ICustomerLogoService, CustomerLogoService>();
			services.AddScoped<IEducationService, EducationService>();
			services.AddScoped<IExperienceService, ExperienceService>();

        }
    }
}
