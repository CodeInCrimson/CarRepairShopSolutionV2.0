// <copyright file="HomePageViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRepairShopSolution.UI.Win.ViewModels;

using CarRepairShopSolution.UI.Win.Commands;
using CarRepairShopSolution.UI.Win.Navigation;
using CarRepairShopSolution.UI.Win.ViewModels.Abstractions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

public partial class HomePageViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;

    public HomePageViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;

        ViewClientsCommand =
            new RelayCommand(navigationService.NavigateTo<ViewAndAddClientsViewModel>);
        ViewCarsCommand =
            new RelayCommand(navigationService.NavigateTo<ViewAndAddClientsViewModel>);
        ManageClientsCommand =
            new RelayCommand(navigationService.NavigateTo<ViewAndAddClientsViewModel>);
        ManageCarsCommand =
            new RelayCommand(navigationService.NavigateTo<ViewAndAddClientsViewModel>);
        //ManageClientsCommand =
        //    new RelayCommand(ShowNotImplemented);
    }

    public ICommand ViewClientsCommand { get; }

    public ICommand ViewCarsCommand { get; }

    public ICommand ManageClientsCommand { get; }

    public ICommand ManageCarsCommand { get; }

    private static void ShowNotImplemented()
    {
        MessageBox.Show(
            "Not implemented.",
            "Information",
            MessageBoxButton.OK,
            MessageBoxImage.Information,
            MessageBoxResult.OK);
    }
}
