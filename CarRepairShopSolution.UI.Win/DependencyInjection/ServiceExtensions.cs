using Microsoft.Extensions.DependencyInjection;

namespace CarRepairShopSolution.UI.Win.DependencyInjection
{
    internal static class ServicesExtensions
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services)
        {
            //services.AddSingleton<MainViewModel>();
            //services.AddTransient<StartScreenViewModel>();

            //RegisterExaminationStepViewModels();

            return services;
        }

        //private static void RegisterExaminationStepViewModels()
        //{
        //    ExaminationStepViewModelFactory.Register<TemperatureExaminationStep, TemperatureViewModel>();
        //}
    }
}
