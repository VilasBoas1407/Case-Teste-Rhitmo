using Api.Data.Context;
using Api.Domain.Interfaces.Repositories;
using Api.Domain.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {

            serviceCollection.AddScoped<IUserRepository, UserRepository>();

            serviceCollection.AddDbContext<ApiContext>();
        }
    }
}
