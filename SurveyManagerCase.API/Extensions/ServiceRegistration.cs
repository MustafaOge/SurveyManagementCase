using MediatR;
using System.Reflection;

namespace SurveyManagement.API.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection collection)
        {
            collection.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            collection.AddHttpClient();
        }
    }
}
