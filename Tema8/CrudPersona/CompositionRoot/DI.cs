using Data.Repositories;
using Domain.Interfaces;
using Domain.Repositories;
using Domain.UseCases;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CompositionRoot
{
    public static class DI
    {
        public static IServiceCollection AddCompositionRoot(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IGetPeopleListRepository, PersonaRepositoryAzure>();
            services.AddScoped<ICRUDUseCase, PersonaCRUDUseCase>();

            return services;
        }
    }
}
