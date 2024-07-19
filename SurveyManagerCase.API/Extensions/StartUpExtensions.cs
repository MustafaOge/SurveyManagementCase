using SurveyManagement.Application.Interfaces.Repositories;
using SurveyManagement.Persistence.Repositories;

namespace SurveyManagement.API.Extensions
{
    public static class StartUpExtensions
    {

        public static IServiceCollection AddScopedWithExtension(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
            services.AddScoped<ISurveyRepository, SurveyRepository>();

            return services;
        }

    }
}
