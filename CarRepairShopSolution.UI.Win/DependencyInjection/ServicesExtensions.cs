using CarRepairShopSolution.UI.Win.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace CarRepairShopSolution.UI.Win.DependencyInjection
{
    internal static class ServicesExtensions
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services)
        {
            // Register ViewModels
            services.AddSingleton<MainViewModel>();
            services.AddTransient<HomePageViewModel>();
            services.AddTransient<ViewAndAddClientsViewModel>();
            services.AddTransient<ViewAndAddCarsViewModel>();
            return services;
        }
    }
}
