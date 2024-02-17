// <copyright file="App.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRepairShopSolution.UI.Win;

using System.Diagnostics;
using System.IO;
using System.Windows;
using CarRepairShopSolution.ApplicationServices.RepositoryMappings;
using CarRepairShopSolution.Infrastructure.Persistence.DatabaseContextInit;
using CarRepairShopSolution.Infrastructure.Persistence.DbModels;
using CarRepairShopSolution.Infrastructure.Persistence.Repositories;
using CarRepairShopSolution.UI.Win.DependencyInjection;
using CarRepairShopSolution.UI.Win.Navigation;
using CarRepairShopSolution.UI.Win.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

/// <summary>
/// Interaction logic for App.xaml.
/// </summary>
public partial class App : Application
{
    private readonly ServiceProvider _serviceProvider;

    public static IConfiguration? Config { get; private set; }

    public App()
    {
        ServiceCollection services = new ServiceCollection();

        ConfigureServices(services);
        _serviceProvider = services.BuildServiceProvider();

        Config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(Config)
            .CreateLogger();

        // Ensure any configuration errors in Serilog are caught
        Serilog.Debugging.SelfLog.Enable(msg => Debug.WriteLine(msg));

        Log.Information("Application Starting Up");
    }

    private void ConfigureServices(ServiceCollection services)
    {
        // TODO: Setup Configuration and Serilog

        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        //services.AddInfrastructure(Config.GetConnectionString("DefaultConnection"));

        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite("Data Source=carRepairShop.db"));

        //services.AddDbContext<AppDbContext>(options =>
        //    options.UseSqlite(Config.GetConnectionString("DefaultConnection")));

        // Register the generic repository for dependency injection
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        services.AddScoped<IClientRepository, ClientRepository>();

        // Register NavigationService for DI
        services.AddScoped<INavigationService, NavigationService>();

        services.AddScoped<ClientService>();
        services.AddScoped<CarService>();

        services.AddViewModels();

        // Add repository registrations
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var navigationService = _serviceProvider.GetRequiredService<INavigationService>();
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();

        navigationService.NavigateTo<HomePageViewModel>();

        MainWindow mainWindow = new () { DataContext = mainViewModel };
        mainWindow.Show();

        Log.Information("Application starting up");
    }

    protected override void OnExit(ExitEventArgs e)
    {
        Log.Information("Application Shutting Down");
        Log.CloseAndFlush();
        base.OnExit(e);
    }
}
