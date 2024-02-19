// <copyright file="App.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRepairShopSolution.UI.Win;

using System.Diagnostics;
using System.IO;
using System.Windows;
using CarRepairShopSolution.ApplicationServices.RepositoryMappings;
using CarRepairShopSolution.Infrastructure.Persistence.DatabaseContextInit;
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

    /// <summary>
    ///     Initializes a new instance of the <see cref="App"/> class.
    /// </summary>
    public App()
    {
        ServiceCollection services = new ServiceCollection();

        ConfigureLogger();
        ConfigureServices(services);

        _serviceProvider = services.BuildServiceProvider();

        // Ensure any configuration errors in Serilog are caught
        Serilog.Debugging.SelfLog.Enable(msg => Debug.WriteLine(msg));

        Log.Information("Application Starting Up");
    }

    /// <summary>
    /// TODO: .
    /// </summary>
    public static IConfiguration? Config { get; private set; }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        try
        {
            var navigationService = _serviceProvider.GetRequiredService<INavigationService>();
            var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();

            navigationService.NavigateTo<HomePageViewModel>();

            MainWindow mainWindow = new () { DataContext = mainViewModel };
            mainWindow.Show();

            Log.Information("Application starting up");
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "A critical error occurred.");
            throw;
        }
    }

    protected override void OnExit(ExitEventArgs e)
    {
        Log.Information("Application Shutting Down");
        Log.CloseAndFlush();
        base.OnExit(e);
    }

    private void ConfigureServices(ServiceCollection services)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        //services.AddInfrastructure(Config.GetConnectionString("DefaultConnection"));

        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite("Data Source=carRepairShopV2.db"));

        // Register the generic repository and specific repositories
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<ICarRepository, CarRepository>();

        // Register NavigationService for DI
        services.AddScoped<INavigationService, NavigationService>();

        services.AddScoped<ClientService>();
        services.AddScoped<CarService>();

        services.AddViewModels();
    }

    private void ConfigureLogger()
    {
        Config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(Config)
            .CreateLogger();

        /*
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Is(Debugger.IsAttached ? LogEventLevel.Debug : LogEventLevel.Information)
            .ReadFrom.Configuration(Config)
            .WriteTo.EventLog("CarRepairShopSolution.UI.Win", "CarRepairShopSolution")
            .Enrich.WithProperty("ApplicationName", "CarRepairShopSolution")
            .Enrich.WithProperty("ApplicationVersion", "2.0")
            .Enrich.FromLogContext()
            .CreateLogger(); */
    }
}
