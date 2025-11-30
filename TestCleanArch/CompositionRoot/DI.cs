using Data.Repositories;
using Domain.Repositories;
using Domain.Interfaces;
using Domain.UseCases;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace CompositionRoot
{
    public static class DI
    {
        public static IServiceCollection AddCompositionRoot(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICRUDPeopleRepository, PersonaRepositoryAzure>();
            services.AddScoped<ICRUDPeopleUseCase, CRUDPersonaUseCase>();
            services.AddScoped<ICRUDDepartamentoRepository, DepartamentoRepo>();
            services.AddScoped<ICRUDDepartamentoUseCase, CRUDDepartamentoUseCase>();
            return services;
        }
    }
}
