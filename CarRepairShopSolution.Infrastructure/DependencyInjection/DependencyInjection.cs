using Microsoft.Extensions.DependencyInjection;

namespace CarRepairShopSolution.Infrastructure.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            //var assembly = typeof(DependencyInjection).Assembly;

            //services.AddMediatR(configuration =>
            //    configuration.RegisterServicesFromAssembly(assembly));

            //services.AddValidatorsFromAssembly(assembly);

            return services;
        }
    }
}
