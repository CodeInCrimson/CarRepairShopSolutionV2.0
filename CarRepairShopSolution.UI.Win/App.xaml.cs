// <copyright file="App.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace CarRepairShopSolution.UI.Win;

using System.Diagnostics;
using System.Windows;
using Microsoft.Extensions.Configuration;
using Serilog;

/// <summary>
/// Interaction logic for App.xaml.
/// </summary>
public partial class App : Application
{
    public static IConfiguration? Config { get; private set; }

    public App()
    {
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

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        Log.Information("Application starting up");
    }

    protected override void OnExit(ExitEventArgs e)
    {
        Log.Information("Application Shutting Down");
        Log.CloseAndFlush();
        base.OnExit(e);
    }
}
