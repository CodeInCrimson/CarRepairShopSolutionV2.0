using Microsoft.Extensions.DependencyInjection;

namespace CarRepairShopSolution.UI.Win.DependencyInjection
{
    internal static class ServicesExtensions
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services)
        {
            //services.AddSingleton<MainViewModel>();

            //services.AddTransient<StartScreenViewModel>();
            //services.AddTransient<LoginScreenViewModel>();
            //services.AddTransient<CreateAccountViewModel>();
            //services.AddTransient<OperationsScreenViewModel>();
            //services.AddTransient<DigitalExaminationListViewModel>();
            //services.AddTransient<FaceRegistrationViewModel>();
            //services.AddTransient<FaceIdentificationViewModel>();
            //services.AddTransient<FaceLoginViewModel>();
            //services.AddTransient<ExaminationHistoryViewModel>();
            //services.AddTransient<ExaminationReportViewModel>();
            //services.AddTransient<ProfileManagementViewModel>();
            //services.AddTransient<EmergencyContactScreenViewModel>();
            //services.AddTransient<NeuroExaminationViewModel>();
            //services.AddTransient<FaceAbnormalityDetectedViewModel>();
            //services.AddTransient<ConnectedDevicesViewModel>();
            //services.AddTransient<HealthStatisticsViewModel>();

            //services.AddSingleton<IExaminationStepViewModelFactory, ExaminationStepViewModelFactory>();

            //services.AddTransient<QuestionnaireViewModel>();
            //services.AddTransient<MoleExistingQuestionViewModel>();
            //services.AddTransient<MoleChangesQuestionViewModel>();
            //services.AddTransient<MoleDurationQuestionViewModel>();
            //services.AddTransient<FamilyCancerQuestionViewModel>();
            //services.AddTransient<FeelUncomfortableQuestionViewModel>();

            //RegisterExaminationStepViewModels();

            return services;
        }

        //private static void RegisterExaminationStepViewModels()
        //{
        //    ExaminationStepViewModelFactory.Register<TemperatureExaminationStep, TemperatureViewModel>();
        //    ExaminationStepViewModelFactory.Register<BloodPressureExaminationStep, BloodPressureViewModel>();
        //    ExaminationStepViewModelFactory.Register<FacialDroopWithSmileExaminationStep, FacialDroopWithSmileViewModel>();
        //    ExaminationStepViewModelFactory.Register<ArmMotorFunctionExaminationStep, ArmMotorFunctionViewModel>();
        //    ExaminationStepViewModelFactory.Register<LegMotorFunctionExaminationStep, LegMotorFunctionViewModel>();
        //    ExaminationStepViewModelFactory.Register<HeadAndGazeDeviationExaminationStep, HeadAndGazeDeviationViewModel>();
        //    ExaminationStepViewModelFactory.Register<WeakBodySideExaminationStep, WeakBodySideViewModel>();

        //    ExaminationStepViewModelFactory.Register<MoleExistingExaminationStep, MoleExistingQuestionViewModel>();
        //    ExaminationStepViewModelFactory.Register<MoleChangesExaminationStep, MoleChangesQuestionViewModel>();
        //    ExaminationStepViewModelFactory.Register<MoleDurationExaminationStep, MoleDurationQuestionViewModel>();
        //    ExaminationStepViewModelFactory.Register<FamilyCancerExaminationStep, FamilyCancerQuestionViewModel>();
        //    ExaminationStepViewModelFactory.Register<FeelUncomfortableExaminationStep, FeelUncomfortableQuestionViewModel>();
        //}
    }

}
