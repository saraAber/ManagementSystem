
using BLL.Interface;
using BLL.Service;
using DAL;
using log4net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace BLL
{
    public static class ServiceCollectionExtention
    {
        public static void AddServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddAutoMapper(config => config.AddProfile<MapProfile>());
            serviceCollection.AddScoped<IEmployeeBLL, EmployeeBLL>();
            serviceCollection.AddScoped<IManagerBLL, ManagerBLL>();


            serviceCollection.AddRepositories(configuration);
        }
    }
}
